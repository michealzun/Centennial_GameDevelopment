module objects {
    export class Background extends createjs.Bitmap {
        // Variables
        private speedY : number;

        // Constructor
        constructor(assetManager: createjs.LoadQueue,x:string) {
            super(assetManager.getResult(x));

            this.Start();
        }
        // Methods / Function
        public Start():void {
            this.speedY = 1;
            this.Reset();
        }

        public Update():void {
            // Move our background
            this.Move();
            // Check bounds
            this.CheckBounds();
        }

        private Reset():void {
            this.y = -1120;
        }

        private Move():void {
            this.y += this.speedY;
        }

        private CheckBounds():void {
            if(this.y >= 0) {
                this.Reset();
            }
        }
    }
}