using ConnectFour;

class Program
{
    public static void Main(string[] args)
    {
        Grid grid = new Grid(6, 7);
        Game game = new Game(grid, 4, 10);
        game.Play();
    }
}