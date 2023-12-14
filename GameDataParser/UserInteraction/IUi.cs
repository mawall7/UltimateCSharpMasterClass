namespace GameDataParser
{
    public interface IUi
    {
        public void ShowMessage(string message);
        public void Exit();
        public void ReadInput();
        public void PrintGameData();

        public void PrintError(string errormessage);
    }
}

    

   





