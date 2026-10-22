namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Event names and payload keys for the course schema
    /// (matches the Stage 01 "Event Design" slide).
    /// </summary>
    public static class AnalyticsEvents
    {
        // --- event names (snake_case — stable forever) ---
        public const string SESSION_START = "session_start";
        public const string SESSION_END   = "session_end";
        public const string GAME_START    = "game_start";
        public const string GAME_OVER     = "game_over";
        public const string PURCHASE      = "purchase";

        // --- payload keys ---
        public const string KEY_SCENE     = "scene";
        public const string KEY_DEVICE_OS = "device_os";
        public const string KEY_SCORE     = "score";
        public const string KEY_DURATION  = "duration_s";
        public const string KEY_ATTEMPTS  = "attempts";
        public const string KEY_ITEM_ID   = "item_id";
        public const string KEY_PRICE     = "price_usd";
    }
}
