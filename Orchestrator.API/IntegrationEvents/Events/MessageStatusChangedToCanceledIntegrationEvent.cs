namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

//Refact: немного не понял зачем так много однотипных контрактов с очень длинными названиями, 
//посмори как называются у нас в проекте называются контракты и поправь и еще у нас все контракты лежат в одном репозитории StableDraw.Contracts нужно будет это перенести туда
//Подумай как сократить их количество чтобы не было куча однотипных контрактов (Названия по тому куда мы отправляем и зачем)
public record MessageStatusChangedToCanceledIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}