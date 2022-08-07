﻿using ImproveGame.Common.Animations;

namespace ImproveGame.Interface.UIElements_Shader
{
    public class BackgroundImage : UIElement
    {
        public Color background = new(35, 40, 83);

        private Texture2D texture;
        private Vector2 textureSize;
        public Texture2D Texture
        {
            get => texture;
            set
            {
                texture = value;
                textureSize = value.Size();
            }
        }

        public BackgroundImage(Texture2D texture)
        {
            Texture = texture;
            PaddingLeft = 14;
            PaddingRight = 14;
            PaddingTop = 5;
            PaddingBottom = 5;
            Width.Pixels = textureSize.X + this.HPadding();
            Height.Pixels = textureSize.Y + this.VPadding();
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            SoundEngine.PlaySound(SoundID.MenuTick);
        }

        protected override void DrawSelf(SpriteBatch sb)
        {
            CalculatedStyle rectangle = GetDimensions();
            Vector2 position = rectangle.Position();
            Vector2 size = rectangle.Size();

            PixelShader.DrawBox(Main.UIScaleMatrix, position, size, 10, 0, background, background);

            rectangle = GetInnerDimensions();
            position = rectangle.Position();
            size = rectangle.Size();
            sb.Draw(Texture, position + size / 2 - textureSize / 2f, IsMouseHovering ? Color.White : Color.White * 0.5f);
        }

    }
}
