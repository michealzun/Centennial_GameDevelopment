module objects {
    export class Button extends createjs.Bitmap {
        // Variables
        // Constructor
        constructor(assetManager: createjs.LoadQueue, imageString:string, x:number = 0, y:number = 0) {
            super(assetManager.getResult(imageString));   
            this.regX = this.getBounds().width * 0.5;
            this.regY = this.getBounds().height * 0.5;

            this.x = x;
            this.y = y;

            // Setup event handlers
            this.on("mouseover", this.mouseOver);
            this.on("mouseout", this.mouseOut);
            // this.on("mouseclick", this.mouseClick);
        }
        // Methods
        private mouseOver():void {
            this.alpha = 0.7;
        }

        private mouseOut():void {
            this.alpha = 1.0;
        }
    }
}