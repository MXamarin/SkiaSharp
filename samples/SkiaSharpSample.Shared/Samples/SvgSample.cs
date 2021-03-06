﻿using System;
using System.Threading.Tasks;
using SkiaSharp;

namespace SkiaSharpSample.Samples
{
	[Preserve(AllMembers = true)]
	public class SvgSample : SampleBase
	{
		private SKSvg svg;

		[Preserve]
		public SvgSample()
		{
		}

		public override string Title => "SVG";

		public override SampleCategories Category => SampleCategories.BitmapDecoding | SampleCategories.SVG;

		protected override Task OnInit()
		{
			svg = new SKSvg();
			using (var stream = SampleMedia.Images.LogosSvg)
				svg.Load(stream);

			return base.OnInit();
		}

		protected override void OnDrawSample(SKCanvas canvas, int width, int height)
		{
			canvas.Clear(SKColors.White);

			float canvasMin = Math.Min(width, height);
			float svgMax = Math.Max(svg.Picture.CullRect.Width, svg.Picture.CullRect.Height);
			float scale = canvasMin / svgMax;
			var matrix = SKMatrix.MakeScale(scale, scale);

			canvas.DrawPicture(svg.Picture, ref matrix);
		}
	}
}
