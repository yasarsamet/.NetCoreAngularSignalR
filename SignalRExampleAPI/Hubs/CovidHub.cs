using Microsoft.AspNetCore.SignalR;
using SignalRExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExampleAPI.Hubs
{
    public class CovidHub:Hub
    {
        private readonly CovidService _covidService;

        public CovidHub(CovidService covidService)
        {
            _covidService = covidService;
        }
        public async Task GetCovidList()
        {
            await Clients.All.SendAsync("ReceiveCovidList", _covidService.GetCovidChartList());
        }
    }
}
