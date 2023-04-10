// using src.models;


// namespace src.games.ConnectFour;


// public class ConnectFourState : IState
// {
//     public List<List<int>> Squares { get; private set;}
//     public int Size;


//     public ConnectFourState(int size)
//     {
//         Squares = initialiseSquares(size);
//         Size = size;

//     }
    
//     public ConnectFourState(ConnectFourState other)
//     {

//     }

//     public void Update(int player, Move moveLocation)
//     {

//     }

//     public bool HasWinner(int player, Move moveLocation)
//     {

//         return false;
//     }

//     public override int GetHashCode()
//     {
//         var squaresString = "";
//         foreach (List<int> row in Squares)
//         {
//             squaresString += String.Join("", row);
//         }

//         return squaresString.GetHashCode();
//     }

//     private static List<List<int>> initialiseSquares(int size)
//     {
//         var output = new List<List<int>>();
//         foreach (int i in Enumerable.Range(0, size))
//         {
//             output.Add(new List<int>(new int[size]));
//         }

//         return output;
//     }

//     private static List<List<int>> copySquares(List<List<int>> otherSquares)
//     {
//         var output = new List<List<int>>();
//         foreach (List<int> row in otherSquares)
//         {
//             output.Add(new List<int>(row));
//         }

//         return output;
//     }

//     private void validateMoveLocation(int Row, int Column)
//     {
//         if (Squares[Row][Column] != 0)
//         {
//             throw new ArgumentException("The supplied move is invalid as it attempts to use an already occupied location");
//         }
//     }
// }