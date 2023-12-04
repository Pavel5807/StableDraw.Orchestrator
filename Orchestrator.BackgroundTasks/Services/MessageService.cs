using StableDraw.Services.Orchestrator.BackgroundTasks.Models;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.Services;

//Refact: тет не увидел где у нас сообщения хранятся через Redis а если это просто словарик то у нас проблема, тк сервис падает и мы теряем все данные
// надо организовать хранения сообщений, как и в чем опять же на твой выбор
public class MessageService
{
    private readonly Dictionary<Guid, Message> _messages;

    public MessageService()
    {
        _messages = new Dictionary<Guid, Message>();
    }

    public void Add(Message message)
    {
        _messages.Add(message.Id, message);
    }

    public Message? GetFirstByStatus(MessageStatus status)
    {
        return _messages.FirstOrDefault(message => message.Value.Status == status).Value;
    }

    public void SetStatus(Guid id, MessageStatus status)
    {
        if (_messages.ContainsKey(id) is false)
        {
            return;
        }

        _messages[id].Status = status;
    }

    public void Remove(Guid id)
    {
        if (_messages.ContainsKey(id) is false)
        {
            return;
        }

        _messages.Remove(id);
    }
}