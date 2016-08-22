using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using QueueSystem.Models;
using System.Linq;
using AutoMapper;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    public class HeThongSoSignalr
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Singleton instance
        private readonly static Lazy<HeThongSoSignalr> _instance = new Lazy<HeThongSoSignalr>(
            () => new HeThongSoSignalr(GlobalHost.ConnectionManager.GetHubContext<HeThongSoSignalrHub>().Clients));

        private readonly object _marketStateLock = new object();
        private readonly object _updateStockPricesLock = new object();


        private volatile MarketState _marketState;

        private HeThongSoSignalr(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            LoadDefaultStocks();
        }

        public static HeThongSoSignalr Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public MarketState MarketState
        {
            get { return _marketState; }
            private set { _marketState = value; }
        }

        public HeThongSo GetAllStocks(int id)
        {
            HeThongSoViewModels hs = new HeThongSoViewModels();
            hs.ManHinhID = id;
            var xp = Mapper.Map<HeThongSoViewModels, HeThongSo>(hs);
            HeThongSo heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            return heThongSo;
        }

        private void LoadDefaultStocks()
        {
            db.HeThongSos.ToList();
        }

    }
}