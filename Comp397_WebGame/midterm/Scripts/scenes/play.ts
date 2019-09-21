module scenes {
    export class PlayScene extends objects.Scene {
        private background:objects.Background;
        private player:objects.Player;
        private collide:boolean;
        private bushes:objects.bush[];
        private traps:objects.trap[];
        private tileSize:number;

        private backgroundMusic:createjs.AbstractSoundInstance;

        // Constructor
        constructor(assetManager:createjs.LoadQueue) {
            super(assetManager);
            this.background=new objects.Background(this.assetManager,"background2");
            this.background.y=0;
            this.backgroundMusic = createjs.Sound.play("play_music");
            this.backgroundMusic.loop = -1; // Looping forever
            this.backgroundMusic.volume = 0.02;
            this.tileSize=64;
            this.Start();
        }
        // Methods
        public Start(): void {

            this.player = new objects.Player(this.assetManager,this.tileSize*0.5,this.tileSize*7.5);
            this.spawnMap();
            this.Main();
        }
        public spawnMap(): void {
            
            //http://www.crystalinks.com/maze.html
            this.bushes = new Array<objects.bush>();
            this.bushes[0]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*0.5);
            this.bushes[1]=new objects.bush(this.assetManager,this.tileSize*1.5,this.tileSize*0.5);
            this.bushes[2]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*0.5);
            this.bushes[3]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*0.5);
            this.bushes[4]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*0.5);
            this.bushes[5]=new objects.bush(this.assetManager,this.tileSize*5.5,this.tileSize*0.5);
            this.bushes[6]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*0.5);
            this.bushes[7]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*0.5);
            this.bushes[8]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*0.5);
            this.bushes[9]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*0.5);
            this.bushes[10]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*0.5);
            this.bushes[11]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*0.5);
            this.bushes[12]=new objects.bush(this.assetManager,this.tileSize*13.5,this.tileSize*0.5);
            this.bushes[13]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*0.5);
            this.bushes[14]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*1.5);
            this.bushes[15]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*1.5);
            this.bushes[16]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*1.5);
            this.bushes[17]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*1.5);
            this.bushes[18]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*2.5);
            this.bushes[19]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*2.5);
            this.bushes[20]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*2.5);
            this.bushes[21]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*2.5);
            this.bushes[22]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*2.5);
            this.bushes[23]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*2.5);
            this.bushes[24]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*2.5);
            this.bushes[25]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*2.5);
            this.bushes[26]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*2.5);
            this.bushes[27]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*2.5);
            this.bushes[28]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*2.5);
            this.bushes[29]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*3.5);
            this.bushes[30]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*3.5);
            this.bushes[31]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*3.5);
            this.bushes[32]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*3.5);
            this.bushes[33]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*3.5);
            this.bushes[34]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*3.5);
            this.bushes[35]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*4.5);
            this.bushes[36]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*4.5);
            this.bushes[37]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*4.5);
            this.bushes[38]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*4.5);
            this.bushes[39]=new objects.bush(this.assetManager,this.tileSize*7.5,this.tileSize*4.5);
            this.bushes[40]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*4.5);
            this.bushes[41]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*4.5);
            this.bushes[42]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*4.5);
            this.bushes[43]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*4.5);
            this.bushes[44]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*4.5);
            this.bushes[45]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*5.5);
            this.bushes[46]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*5.5);
            this.bushes[47]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*5.5);
            this.bushes[48]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*5.5);
            this.bushes[49]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*6.5);
            this.bushes[50]=new objects.bush(this.assetManager,this.tileSize*1.5,this.tileSize*6.5);
            this.bushes[51]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*6.5);
            this.bushes[52]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*6.5);
            this.bushes[53]=new objects.bush(this.assetManager,this.tileSize*5.5,this.tileSize*6.5);
            this.bushes[54]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*6.5);
            this.bushes[55]=new objects.bush(this.assetManager,this.tileSize*7.5,this.tileSize*6.5);
            this.bushes[56]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*6.5);
            this.bushes[57]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*6.5);
            this.bushes[58]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*6.5);
            this.bushes[59]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*6.5);
            this.bushes[60]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*6.5);
            this.bushes[61]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*6.5);
            this.bushes[62]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*7.5);
            this.bushes[63]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*7.5);
            this.bushes[64]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*7.5);
            this.bushes[65]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*8.5);
            this.bushes[66]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*8.5);
            this.bushes[67]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*8.5);
            this.bushes[68]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*8.5);
            this.bushes[69]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*8.5);
            this.bushes[70]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*8.5);
            this.bushes[71]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*8.5);
            this.bushes[72]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*8.5);
            this.bushes[73]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*8.5);
            this.bushes[74]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*8.5);
            this.bushes[75]=new objects.bush(this.assetManager,this.tileSize*13.5,this.tileSize*8.5);
            this.bushes[76]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*8.5);
            this.bushes[77]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*9.5);
            this.bushes[78]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*9.5);
            this.bushes[79]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*9.5);
            this.bushes[80]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*9.5);
            this.bushes[81]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*9.5);
            this.bushes[82]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*10.5);
            this.bushes[83]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*10.5);
            this.bushes[84]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*10.5);
            this.bushes[85]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*10.5);
            this.bushes[86]=new objects.bush(this.assetManager,this.tileSize*7.5,this.tileSize*10.5);
            this.bushes[87]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*10.5);
            this.bushes[88]=new objects.bush(this.assetManager,this.tileSize*9.5,this.tileSize*10.5);
            this.bushes[89]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*10.5);
            this.bushes[90]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*10.5);
            this.bushes[91]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*10.5);
            this.bushes[92]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*10.5);
            this.bushes[93]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*11.5);
            this.bushes[94]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*11.5);
            this.bushes[95]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*11.5);
            this.bushes[96]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*11.5);
            this.bushes[97]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*11.5);
            this.bushes[98]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*12.5);
            this.bushes[99]=new objects.bush(this.assetManager,this.tileSize*1.5,this.tileSize*12.5);
            this.bushes[100]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*12.5);
            this.bushes[101]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*12.5);
            this.bushes[102]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*12.5);
            this.bushes[103]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*12.5);
            this.bushes[104]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*12.5);
            this.bushes[105]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*12.5);
            this.bushes[106]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*12.5);
            this.bushes[107]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*12.5);
            this.bushes[108]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*13.5);
            this.bushes[109]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*13.5);
            this.bushes[110]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*13.5);
            this.bushes[111]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*13.5);
            this.bushes[112]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*13.5);
            this.bushes[113]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*13.5);
            this.bushes[114]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*13.5);
            this.bushes[115]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*14.5);
            this.bushes[116]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*14.5);
            this.bushes[117]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*14.5);
            this.bushes[118]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*14.5);
            this.bushes[119]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*14.5);
            this.bushes[120]=new objects.bush(this.assetManager,this.tileSize*7.5,this.tileSize*14.5);
            this.bushes[121]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*14.5);
            this.bushes[122]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*14.5);
            this.bushes[123]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*14.5);
            this.bushes[124]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*14.5);
            this.bushes[125]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*15.5);
            this.bushes[126]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*15.5);
            this.bushes[127]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*15.5);
            this.bushes[128]=new objects.bush(this.assetManager,this.tileSize*0.5,this.tileSize*16.5);
            this.bushes[129]=new objects.bush(this.assetManager,this.tileSize*1.5,this.tileSize*16.5);
            this.bushes[130]=new objects.bush(this.assetManager,this.tileSize*2.5,this.tileSize*16.5);
            this.bushes[131]=new objects.bush(this.assetManager,this.tileSize*3.5,this.tileSize*16.5);
            this.bushes[132]=new objects.bush(this.assetManager,this.tileSize*4.5,this.tileSize*16.5);
            this.bushes[133]=new objects.bush(this.assetManager,this.tileSize*5.5,this.tileSize*16.5);
            this.bushes[134]=new objects.bush(this.assetManager,this.tileSize*6.5,this.tileSize*16.5);
            this.bushes[135]=new objects.bush(this.assetManager,this.tileSize*7.5,this.tileSize*16.5);
            this.bushes[136]=new objects.bush(this.assetManager,this.tileSize*8.5,this.tileSize*16.5);
            this.bushes[137]=new objects.bush(this.assetManager,this.tileSize*10.5,this.tileSize*16.5);
            this.bushes[138]=new objects.bush(this.assetManager,this.tileSize*11.5,this.tileSize*16.5);
            this.bushes[139]=new objects.bush(this.assetManager,this.tileSize*12.5,this.tileSize*16.5);
            this.bushes[140]=new objects.bush(this.assetManager,this.tileSize*13.5,this.tileSize*16.5);
            this.bushes[141]=new objects.bush(this.assetManager,this.tileSize*14.5,this.tileSize*16.5);
        
            this.traps = new Array<objects.trap>();
            this.traps[0]=new objects.trap(this.assetManager,this.tileSize*1.5,this.tileSize*5.5);
            this.traps[1]=new objects.trap(this.assetManager,this.tileSize*9.5,this.tileSize*1.5);
            this.traps[2]=new objects.trap(this.assetManager,this.tileSize*7.5,this.tileSize*13.5);
            this.traps[3]=new objects.trap(this.assetManager,this.tileSize*3.5,this.tileSize*3.5);
            this.traps[4]=new objects.trap(this.assetManager,this.tileSize*3.5,this.tileSize*9.5);
            this.traps[5]=new objects.trap(this.assetManager,this.tileSize*3.5,this.tileSize*13.5);
        }
        public Update(): void {
            this.player.Update();
            //wall detection
            this.collide=false;
            this.bushes.forEach(bush => {
                if(managers.Collision.Check(this.player, bush))
                    this.collide=true;
            });
            if(this.collide){
                this.player.x=this.player.preX;
                this.player.y=this.player.preY;
            }
            //trap detection
            this.collide=false;
            this.traps.forEach(trap => {
                if(managers.Collision.Check(this.player, trap))
                    this.collide=true;
            });
            if(this.collide){
                this.player.x=this.tileSize*0.5;
                this.player.y=this.tileSize*7.5;
            }
            //end game
            if (this.player.x>this.tileSize*16.5)
            objects.Game.currentScene = config.Scene.OVER;
        }

        public Main(): void {
            this.addChild(this.background);
            this.bushes.forEach(bush => {
                this.addChild(bush);
            });
            this.traps.forEach(trap => {
                this.addChild(trap);
            });
            this.addChild(this.player);
        }
    }
}