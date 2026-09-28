using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Services.Games
{
    internal interface IGamesService
    {
        void CreateGame();
        void DeleteGame();
        void UpdateGame();
        void GetAllGames();
        void Filter();
    }
}
