using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Client;

public class ClientViewModel : ViewModelBase, INavItem
{
    public INavHost Host { get; set; }
    
    private Database.Client _client = new Database.Client() 
    {
        ImagePath = "../../Resources/dore.png",
        Name = "Дора",
        Description = 
            @"Закрываю дверь квартиры Отключаю все мобилы Недоступна для дебилов Потому что я влюбилась В тебя-а-а, тупого наглеца             От чего же? От чего же             Всё потому, что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             (Дура, дура, дура)             Я увидела твой взгляд             Заострённый на мне             Ты рукою помахал             Я помахала в ответ             Ты пошёл ко мне навстречу             Это было так глупо             Ведь за спиною моей             Стояла твоя подруга (подруга)             Всё потому, что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Ты позвал меня на встречу (а)             Ты позвал меня на встречу             Я готовилась весь вечер             Выбирала, что надеть мне             Истрепала свои нервы             Пришла, ждала почти два часа             И ты написал: Сорри, я проспал             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура             Потому что Дора — дура             Супердура, Дора — дура"
    };
    
    public CommandHandler EditCommand =>
        new CommandHandler(Edit);
    
    public CommandHandler UnLoginCommand =>
        new CommandHandler(UnLogin);
    
    public ClientViewModel(INavHost host)
    {
        Host = host;
    }
    
    private void Edit()
    {
        Host.NavController.Navigate(new EditClientPage(Host, Client));
    }
    
    private void UnLogin()
    {
        
    }
    
    public Database.Client Client
    {
        get => _client;
        set
        {
            if (Equals(value, _client)) return;
            _client = value;
            OnPropertyChanged();
        }
    }
    
    
}