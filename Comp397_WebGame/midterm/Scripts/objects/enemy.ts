module objects {
    export class Enemy extends objects.GameObject {
        // Variables
        // Constructor
        constructor(assetManager:createjs.LoadQueue) {
            super(assetManager, "enemy");
            this.Start();
        }
        // Method / Functions
        public Start():void {}
        public Update():void {}
        public Reset():void {}
        public Move():void {}
        public CheckBounds():void { }
    }
}