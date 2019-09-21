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
    var trap = /** @class */ (function (_super) {
        __extends(trap, _super);
        function trap(assetManager, y, x) {
            if (y === void 0) { y = 0; }
            if (x === void 0) { x = 0; }
            var _this = _super.call(this, assetManager, "trap") || this;
            _this.x = x;
            _this.y = y;
            _this.Start();
            return _this;
        }
        trap.prototype.Start = function () { };
        trap.prototype.Update = function () { };
        trap.prototype.Reset = function () { };
        trap.prototype.CheckBounds = function () { };
        trap.prototype.Move = function () { };
        return trap;
    }(objects.GameObject));
    objects.trap = trap;
})(objects || (objects = {}));
//# sourceMappingURL=trap.js.map