using System.Collections;
using UnityEngine;

namespace Common {
    public static class SceneMode {
        public const int TITLE = 0;
        public const int GAME_SELECT = 1;
        public const int NEW_GAME_WAIT = 2;
        public const int EXIT_WAIT = 6;
    }

    public static class SelectMode {
        public const int NEW_GAME = 0;
        public const int LOAD_GAME = 1;
        public const int ACHIEVEMENT = 2;
        public const int CONFIG = 3;
        public const int EXIT = 4;
    }

    public static class FadeMode {
        public const int LOAD_SCENE = 0;
        public const int LOAD_MAP = 1;
    }
}
