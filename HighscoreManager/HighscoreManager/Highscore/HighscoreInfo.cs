using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighscoreManager.Highscore
{
  public class HighscoreInfo
  {
    public String playerName { get; set; }
    public int score { get; set; }

    public HighscoreInfo(string playerName, int score)
    {
      this.playerName = playerName;
      this.score = score;
    }

    public override string ToString()
    {
      return String.Format("{0} : {1}", this.playerName, this.score);
    }
  }
}
