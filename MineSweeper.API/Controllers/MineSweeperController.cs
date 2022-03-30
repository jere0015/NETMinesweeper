using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MineSweeperController : ControllerBase
    {
        private readonly ILogger<MineSweeperController> _logger;

        private MineSweeper.Engine _engine;

        public MineSweeperController(ILogger<MineSweeperController> logger)
        {
            _logger = logger;
        }


        // Returns board state in json format
        [HttpGet]
        public IActionResult GetState()
        {

        }

        // Sends input to minesweeper engine
        [HttpPost]
        public IActionResult SendInput(object command)
        {
            _engine.SendInput(command);
        }
    }
}
