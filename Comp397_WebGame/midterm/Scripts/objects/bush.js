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
    var bush = /** @class */ (function (_super) {
        __extends(bush, _super);
        function bush(assetManager, y, x) {
            if (y === void 0) { y = 0; }
            if (x === void 0) { x = 0; }
            var _this = _super.call(this, assetManager, "bush") || this;
            _this.x = x;
            _this.y = y;
            _this.Start();
            return _this;
        }
        bush.prototype.Start = function () { };
        bush.prototype.Update = function () { };
        bush.prototype.Reset = function () { };
        bush.prototype.CheckBounds = function () { };
        bush.prototype.Move = function () { };
        return bush;
    }(objects.GameObject));
    objects.bush = bush;
})(objects || (objects = {}));
//# sourceMappingURL=bush.js.map