module objects {
    export class Player extends objects.GameObject {
        public preX:number;
        public preY:number;


        constructor(assetManager:createjs.LoadQueue,x:number=0,y:number=0) {
            super(assetManager, "player");
            this.x = x;
            this.y = y;
            this.Start();
        }

        public Start():void {
            this.preX=this.x;
            this.preY=this.y;
        }

        public Update():void {
            this.preX=this.x;
            this.preY=this.y;
            this.Move();
            this.CheckBounds();
        }

        public Reset():void {}

        public Move():void {


            if(objects.Game.keyboardManager.moveUp) {
                this.y -= 5;
            }
            if(objects.Game.keyboardManager.moveDown) {
                this.y += 5;
            }
            if(objects.Game.keyboardManager.moveLeft) {
                this.x -= 5;
            }
            if(objects.Game.keyboardManager.moveRight) {
                this.x += 5;
            }
        }

        public CheckBounds():void {
            // Check right boundary
            if(this.x >= 1088 - this.halfW) {
                this.x = 1088 - this.halfW;
            }

            // Check left boundary
            if(this.x <= this.halfW) {
                this.x = this.halfW;
            }

            if(this.y >= 960 - this.halfH) {
                this.y = 960 - this.halfH;
            }

            // Check left boundary
            if(this.y <= this.halfH) {
                this.y = this.halfH;
            }
        }
    }
}