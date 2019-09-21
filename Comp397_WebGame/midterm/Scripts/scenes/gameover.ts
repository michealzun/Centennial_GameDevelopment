module scenes {
    export class GameOverScene extends objects.Scene {
        // Variables
        private gameOverLabel: objects.Label;
        private MenuLabel: objects.Label;
        private backButton: objects.Button;

        // Constructor
        constructor(assetManager: createjs.LoadQueue) {
            super(assetManager);

            this.Start();
        }

        private backButtonClick():void {
            objects.Game.currentScene = config.Scene.START;
        }


        public Start():void {
            this.gameOverLabel = new objects.Label("YouWin", "40px", "Consolas", "#000000", 544, 240, true);
            this.MenuLabel = new objects.Label("return", "40px", "Consolas", "#000000", 544, 470, true);
            this.backButton = new objects.Button(this.assetManager, "startButton", 554, 500);
            this.Main();
        }

        public Update(): void {

        }

        public Main(): void {
            this.addChild(this.backButton);
            this.addChild(this.gameOverLabel);
            this.addChild(this.MenuLabel);
            this.backButton.on("click", this.backButtonClick);
        }
    }
}