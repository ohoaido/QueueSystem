using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;
using QueueSystem.Models;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    [HubName("heThongSoSignalr")]
    public class HeThongSoSignalrHub : Hub
    {
        private readonly HeThongSoSignalr _hethongso;

        public HeThongSoSignalrHub() :
            this(HeThongSoSignalr.Instance)
        {

        }

        public HeThongSoSignalrHub(HeThongSoSignalr hethongso)
        {
            _hethongso = hethongso;
        }

        public HeThongSo GetAllStocks(int id)
        {
            return _hethongso.GetAllStocks(id);
        }
    }
}