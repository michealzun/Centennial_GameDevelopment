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
var objects;
(function (objects) {
    var Player = /** @class */ (function (_super) {
        __extends(Player, _super);
        function Player(assetManager, x, y) {
            if (x === void 0) { x = 0; }
            if (y === void 0) { y = 0; }
            var _this = _super.call(this, assetManager, "player") || this;
            _this.x = x;
            _this.y = y;
            _this.Start();
            return _this;
        }
        Player.prototype.Start = function () {
            this.preX = this.x;
            this.preY = this.y;
        };
        Player.prototype.Update = function () {
            this.preX = this.x;
            this.preY = this.y;
            this.Move();
            this.CheckBounds();
        };
        Player.prototype.Reset = function () { };
        Player.prototype.Move = function () {
            if (objects.Game.keyboardManager.moveUp) {
                this.y -= 5;
            }
            if (objects.Game.keyboardManager.moveDown) {
                this.y += 5;
            }
            if (objects.Game.keyboardManager.moveLeft) {
                this.x -= 5;
            }
            if (objects.Game.keyboardManager.moveRight) {
                this.x += 5;
            }
        };
        Player.prototype.CheckBounds = function () {
            // Check right boundary
            if (this.x >= 1088 - this.halfW) {
                this.x = 1088 - this.halfW;
            }
            // Check left boundary
            if (this.x <= this.halfW) {
                this.x = this.halfW;
            }
            if (this.y >= 960 - this.halfH) {
                this.y = 960 - this.halfH;
            }
            // Check left boundary
            if (this.y <= this.halfH) {
                this.y = this.halfH;
            }
        };
        return Player;
    }(objects.GameObject));
    objects.Player = Player;
})(objects || (objects = {}));
//# sourceMappingURL=player.js.map