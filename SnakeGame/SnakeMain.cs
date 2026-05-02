namespace SnakeGame
{
    internal class SnakeMain
    {
        static void Main(string[] args)
        {
            Menu myMenu = new Menu();
            Game gameManager = new Game();

            while(true)
            {
                int menuId = myMenu.Choose_Menu();

                switch(menuId)
                {
                    case 1:
                        gameManager.PlayGame();
                        break;
                    case 2:
                        myMenu.How_To_Play();
                        break;
                    case 3:
                        myMenu.Credits();
                        break;
                    case 4:
                        myMenu.exit();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
