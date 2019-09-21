module managers {
    export class ScoreBoard {
        // Variables
        public scoreLabel: objects.Label;

        private score: number;

        // Public properties
        get Score():number {
            return this.score;
        }
        set Score(newScore:number) {
            this.score = newScore;
            this.scoreLabel.text = "Score: " + this.score;
        }

        // Constructor
        constructor() {
            this.Init();
        }
        
        // Methods
        private Init():void {
            this.scoreLabel = new objects.Label("Score: 999999", "20px", "Consolas", "#FFFF00", 10, 10, false);
            this.score = 0;
        }
    }
}