using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneBillingService.Model;
using PhoneBillingService.Service;

namespace PhoneBillingService {

  public class Worker : BackgroundService {
    private readonly ILogger<Worker> _logger;
    private readonly IBillingService _service;
    private readonly IConfiguration _configuration;
    //private List<BI_Mobile> listMobiles = new List<BI_Mobile>();
    //private List<BI_Landline> listLandlines = new List<BI_Landline>();
    //private List<BI_Day> listDays = new List<BI_Day>();
    public Worker(ILogger<Worker> logger, IBillingService service, IConfiguration configuration) {
      _logger = logger;
      _service = service;
      _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
      //await _service.Init();
      while(!stoppingToken.IsCancellationRequested) {
        _logger.LogInformation("Worker running at: {time}");
        _logger.LogInformation("Worker running at: {time}", _configuration.GetConnectionString("DefaultConnection"));
        await Task.Delay(5 * 60000, stoppingToken);
      }
    }
  }
}