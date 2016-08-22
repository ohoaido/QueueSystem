$(function () {

    var ticker = $.connection.heThongSoSignalr, // the generated client-side hub proxy
        $stockTable = $('#stockTable'),
        rowTemplate = '<div>{STT}</div>';
    alert(ticker);
    function init() {
        var url = window.location.pathname;
        alert(url);
        var id = url.substring(url.lastIndexOf('/') + 1);
        return ticker.server.getAllStocks(id).done(function (stocks) {
            $.each(stocks, function () {
                var stock = formatStock(this);
                $stockTable.append(rowTemplate.supplant(stock));
            });
        });
    }

    // Add client-side hub methods that the server will call
    $.extend(ticker.client, {
        marketReset: function () {
            return init();
        }
    });

    // Start the connection
    $.connection.hub.start()
        .then(init)
        .done(function (state) {
            //ticker.client.marketOpened();
        });
});