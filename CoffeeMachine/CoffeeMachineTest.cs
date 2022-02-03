using System.Collections.Generic;
using System.Linq;
using CoffeeMachine.Shared.JsonModel;

namespace CoffeeMachine
{
    public class CoffeeMachineTest
    {
        private readonly IList<DrinkCommand> _commandHistory = new List<DrinkCommand>();

        public string GetDrinkMakerCommand(DrinkCommand userComand)
        {
            var uc = CommandTranslator.GetComand(userComand);
            if(uc.IsValid)
                _commandHistory.Add(userComand);

            return uc.CommandResult;
        }

        public string GetReport()
        {
            var result = "";

            //"Coffee: 1; Cassa: 0.6";

            result += "" + _commandHistory.GroupBy(x => x.DrinkType.Code).FirstOrDefault().Key +
                      _commandHistory.GroupBy(x => x.DrinkType.Code).Count().ToString();
            result += "Cassa: " + _commandHistory.Sum(x => x.DrinkType.Price);
         
            return result;
        }
    }
}
