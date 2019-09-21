var managers;
(function (managers) {
    var Collision = /** @class */ (function () {
        function Collision() {
        }
        Collision.Check = function (player, obj2) {
            // Create 2 temporary Vec2 objects used for collision detections
            var p1 = new math.Vec2(player.x, player.y);
            var p2 = new math.Vec2(obj2.x, obj2.y);
            var leftPointObj1 = player.x - player.halfW;
            var rightPointObj1 = player.x + player.halfW;
            var leftPointObj2 = obj2.x - obj2.halfW;
            var rightPointObj2 = obj2.x + obj2.halfW;
            var upPointObj1 = player.y - player.halfH;
            var downPointObj1 = player.y + player.halfH;
            var upPointObj2 = obj2.y - obj2.halfH;
            var downPointObj2 = obj2.y + obj2.halfH;
            if (((leftPointObj1 <= rightPointObj2 && leftPointObj1 >= leftPointObj2) || (rightPointObj1 >= leftPointObj2 && rightPointObj1 <= rightPointObj2)) && ((upPointObj1 <= downPointObj2 && upPointObj1 >= upPointObj2) || (downPointObj1 >= upPointObj2 && downPointObj1 <= downPointObj2))) {
                return true;
            }
            else {
                return false;
            }
        };
        return Collision;
    }());
    managers.Collision = Collision;
})(managers || (managers = {}));
//# sourceMappingURL=collisions.js.map