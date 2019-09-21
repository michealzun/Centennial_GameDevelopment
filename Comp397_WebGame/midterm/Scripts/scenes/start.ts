module scenes {
    export class StartScene extends objects.Scene {
        // Variables
        private welcomeLabel: objects.Label;
        private creatorLabel: objects.Label;
        private startLabel: objects.Label;
        private startButton: objects.Button;
        private bg:objects.Background;
        
        // Constructors
        constructor(assetManager: createjs.LoadQueue) {
            super(assetManager);

            this.Start();
        }
        // Methods
        private startButtonClick():void {
            objects.Game.currentScene = config.Scene.GAME;
        }

        // Use start function to create objects
        public Start(): void {
            this.welcomeLabel = new objects.Label("ABOVETALE", "60px", "Consolas", "#000000", 544, 240, true);
            this.creatorLabel = new objects.Label("yueyang sun", "24px", "Consolas", "#000000", 544, 340, true);
            this.startLabel = new objects.Label("start", "40px", "Consolas", "#000000", 544, 470, true);
            this.startButton = new objects.Button(this.assetManager, "startButton", 554, 500);
            this.bg = new objects.Background(this.assetManager,"background");
            this.bg.y=0;


            this.Main();
        }

        public Update(): void {
        }

        public Main(): void {
            this.addChild(this.bg);
            this.addChild(this.welcomeLabel);
            this.addChild(this.creatorLabel);
            this.addChild(this.startButton);
            this.addChild(this.startLabel);
            this.startButton.on("click", this.startButtonClick);
        }
    }
}