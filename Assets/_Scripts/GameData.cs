namespace TiltanMobileSummer2026
{
    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public int score;
        public float playTime;

        // Constructor for easy initialization
        public GameData(string name, int score, float time)
        {
            this.playerName = name;
            this.score = score;
            this.playTime = time;
        }

        public GameData()
        {
            
        }
    }
}