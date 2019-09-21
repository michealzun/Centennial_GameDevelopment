var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var scenes;
(function (scenes) {
    var StartScene = /** @class */ (function (_super) {
        __extends(StartScene, _super);
        // Constructors
        function StartScene(assetManager) {
            var _this = _super.call(this, assetManager) || this;
            _this.Start();
            return _this;
        }
        // Methods
        StartScene.prototype.startButtonClick = function () {
            objects.Game.currentScene = config.Scene.GAME;
        };
        // Use start function to create objects
        StartScene.prototype.Start = function () {
            this.welcomeLabel = new objects.Label("ABOVETALE", "60px", "Consolas", "#000000", 544, 240, true);
            this.creatorLabel = new objects.Label("yueyang sun", "24px", "Consolas", "#000000", 544, 340, true);
            this.startLabel = new objects.Label("start", "40px", "Consolas", "#000000", 544, 470, true);
            this.startButton = new objects.Button(this.assetManager, "startButton", 554, 500);
            this.bg = new objects.Background(this.assetManager, "background");
            this.bg.y = 0;
            this.Main();
        };
        StartScene.prototype.Update = function () {
        };
        StartScene.prototype.Main = function () {
            this.addChild(this.bg);
            this.addChild(this.welcomeLabel);
            this.addChild(this.creatorLabel);
            this.addChild(this.startButton);
            this.addChild(this.startLabel);
            this.startButton.on("click", this.startButtonClick);
        };
        return StartScene;
    }(objects.Scene));
    scenes.StartScene = StartScene;
})(scenes || (scenes = {}));
//# sourceMappingURL=start.js.map