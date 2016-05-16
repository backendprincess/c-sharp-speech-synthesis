using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMe
{
    class Boss
    {
        private static FormMain formMain;
        private static FormGame formGame;
        private static FormWordlists formWordlists;
        private static FormAddWordlist formAddWordlist;
        private static FormChooseWordlist formChooseWordlist;
        private static FormInstructions formInstructions;

        public static void init()
        {
            formMain = new FormMain();
            formGame = new FormGame();
            formWordlists = new FormWordlists();
            formAddWordlist = new FormAddWordlist();
            formChooseWordlist = new FormChooseWordlist();
            formInstructions = new FormInstructions();
        }

        public static FormMain getFormMain() { return formMain; }
        public static FormGame getFormGame() { return formGame; }
        public static FormWordlists getFormWordlists() { return formWordlists; }
        public static FormAddWordlist getFormAddWordlist() { return formAddWordlist; }
        public static FormChooseWordlist getFormChooseWordlist() { return formChooseWordlist; }
        public static FormInstructions getFormInstructions() { return formInstructions; }
    }
}
