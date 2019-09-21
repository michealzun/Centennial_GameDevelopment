module objects {
    export class bush extends objects.GameObject {

        constructor(assetManager:createjs.LoadQueue,y:number=0,x:number=0) { 
            super(assetManager, "bush");
            this.x=x;
            this.y=y;
            this.Start();
        }

        public Start():void {}
        public Update():void {}
        public Reset():void {}
        public CheckBounds():void {}
        public Move():void {}
    }
}