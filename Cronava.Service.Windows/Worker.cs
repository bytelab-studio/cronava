using Cronava.Service.Models;
using Cronava.Service.Service;

namespace Cronava.Service.Windows;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            MailAccount account = new MailAccount()
            {
                address = "christoph.koschel86@gmail.com",
                receivingPort = 993,
                receivingServer = "mail.bytelab.studio",
                username = "christoph.koschel86@gmail.com",
            };
            // new IMAP().SyncMails(account);

            await Task.Delay(60 * 1000, stoppingToken);
        }
    }
}
