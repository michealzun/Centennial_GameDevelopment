var managers;
(function (managers) {
    var ScoreBoard = /** @class */ (function () {
        // Constructor
        function ScoreBoard() {
            this.Init();
        }
        Object.defineProperty(ScoreBoard.prototype, "Score", {
            // Public properties
            get: function () {
                return this.score;
            },
            set: function (newScore) {
                this.score = newScore;
                this.scoreLabel.text = "Score: " + this.score;
            },
            enumerable: true,
            configurable: true
        });
        // Methods
        ScoreBoard.prototype.Init = function () {
            this.scoreLabel = new objects.Label("Score: 999999", "20px", "Consolas", "#FFFF00", 10, 10, false);
            this.score = 0;
        };
        return ScoreBoard;
    }());
    managers.ScoreBoard = ScoreBoard;
})(managers || (managers = {}));
//# sourceMappingURL=scoreboard.js.map