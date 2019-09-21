module managers {
    export class Collision {
        private static explodeSFX:createjs.AbstractSoundInstance

        public static Check(player: objects.Player, obj2: objects.GameObject):boolean {
            // Create 2 temporary Vec2 objects used for collision detections
            let p1: math.Vec2 = new math.Vec2(player.x, player.y);
            let p2: math.Vec2 = new math.Vec2(obj2.x, obj2.y);

           let leftPointObj1 = player.x -player.halfW;
           let rightPointObj1 = player.x+ player.halfW;

           let leftPointObj2 = obj2.x-obj2.halfW;
           let rightPointObj2 = obj2.x + obj2.halfW;

           let upPointObj1 = player.y -player.halfH;
           let downPointObj1 = player.y+ player.halfH;

           let upPointObj2 = obj2.y-obj2.halfH;
           let downPointObj2 = obj2.y + obj2.halfH;

           if(((leftPointObj1 <= rightPointObj2 && leftPointObj1>= leftPointObj2) || (rightPointObj1 >= leftPointObj2 && rightPointObj1 <= rightPointObj2))&&((upPointObj1<=downPointObj2&&upPointObj1>=upPointObj2)||(downPointObj1>=upPointObj2 && downPointObj1<=downPointObj2)))
            {
                return true;
            }else {
                return false;
            }
        }
    }
}