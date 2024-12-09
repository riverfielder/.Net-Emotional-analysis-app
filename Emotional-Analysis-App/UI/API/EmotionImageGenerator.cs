

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Drawing;
using System.IO;
using OxyPlot.Annotations;

namespace UI
{
    public class EmotionImageGenerator
    {
        public EmotionImageGenerator() { }


        public BitmapSource GenerateEmotionAnalysisChart(double positiveRatio)
        {
            if (positiveRatio < 0 || positiveRatio > 1)
                throw new ArgumentOutOfRangeException("正向情感百分比必须在 0 到 1 之间。");

            // 创建 PlotModel
            var plotModel = new PlotModel
            {
                Title = "情感分析结果",
                TitleColor = OxyColors.OrangeRed,
                TitleFontSize = 18,
                Background = OxyColors.White
            };

            // 添加 X 轴 (隐藏，但设置范围)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 1,
                IsAxisVisible = false // 隐藏轴线和标签
            });

            // 添加 Y 轴 (隐藏，但设置范围)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 1,
                IsAxisVisible = false // 隐藏轴线和标签
            });

            // 添加条形背景的参考矩形
            var background = new RectangleAnnotation
            {
                MinimumX = 0,
                MaximumX = 1,
                MinimumY = 0.25,
                MaximumY = 0.75,
                Fill = OxyColors.LightGray
            };
            plotModel.Annotations.Add(background);

            // 添加正向情感部分 (橙色部分)
            var positiveAnnotation = new RectangleAnnotation
            {
                MinimumX = 0,
                MaximumX = positiveRatio,
                MinimumY = 0.25,
                MaximumY = 0.75,
                Fill = OxyColors.Orange
            };
            plotModel.Annotations.Add(positiveAnnotation);

            // 添加负向情感部分 (蓝色部分)
            var negativeAnnotation = new RectangleAnnotation
            {
                MinimumX = positiveRatio,
                MaximumX = 1,
                MinimumY = 0.25,
                MaximumY = 0.75,
                Fill = OxyColors.Blue
            };
            plotModel.Annotations.Add(negativeAnnotation);

            // 添加正负情感标注
            plotModel.Annotations.Add(new TextAnnotation
            {
                Text = "正向情感", // 左侧标注
                TextPosition = new DataPoint(0.02, 0.5), // 调整到条形左边附近
                TextHorizontalAlignment = HorizontalAlignment.Left, // 左对齐
                TextVerticalAlignment = VerticalAlignment.Middle, // 垂直居中
                TextColor = OxyColors.Gray,
                FontWeight = OxyPlot.FontWeights.Bold,
                Stroke = OxyColors.Transparent // 无边框
            });

            plotModel.Annotations.Add(new TextAnnotation
            {
                Text = "负向情感", // 右侧标注
                TextPosition = new DataPoint(0.98, 0.5), // 调整到条形右边附近
                TextHorizontalAlignment = HorizontalAlignment.Right, // 右对齐
                TextVerticalAlignment = VerticalAlignment.Middle, // 垂直居中
                TextColor = OxyColors.Gray,
                FontWeight = OxyPlot.FontWeights.Bold,
                Stroke = OxyColors.Transparent // 无边框
            });

            // 添加正向情感百分比 (显示为文本)
            plotModel.Annotations.Add(new TextAnnotation
            {
                Text = $"{positiveRatio * 100:F1}%",
                TextPosition = new DataPoint(positiveRatio - 0.05, 0.85), // 显示在橙色区域上方
                TextColor = OxyColors.Black,
                FontWeight = OxyPlot.FontWeights.Bold
            });

            // 渲染为 Bitmap
            return new PngExporter { Width = 800, Height = 200 }.ExportToBitmap(plotModel);
        }

        // 生成情感变化折线图并返回 BitmapSource
        public BitmapSource GenerateEmotionLineChartAsImage(Dictionary<int, double> emotionData)
        {
            var plotModel = new PlotModel { Title = "情绪变化图" };

            // 添加 X 轴 (时间)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "时间",
                Minimum = 0,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            // 添加 Y 轴 (情绪值)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "情绪值",
                Minimum = -1, // 消极情绪
                Maximum = 1,  // 积极情绪
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                FontSize = 20 // 调整字体大小
            });

            // 添加参考线 (情绪基准线)
            var referenceLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 0,
                Color = OxyColors.Gray,
                StrokeThickness = 2,
                Text = "一般情绪参照点",
                TextHorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 16 // 调整字体大小
            };
            plotModel.Annotations.Add(referenceLine);

            // 添加积极情绪标注
            var positiveEmotionAnnotation = new TextAnnotation
            {
                Text = "积极情绪",
                TextPosition = new DataPoint(2, 0.9), // 设置为正坐标的上方
                TextHorizontalAlignment = HorizontalAlignment.Center,
                TextVerticalAlignment = VerticalAlignment.Top,
                Stroke = OxyColors.Transparent, // 无边框
                TextColor = OxyColors.Green,    // 积极用绿色
                FontWeight = OxyPlot.FontWeights.Bold,
                FontSize = 20 // 调整字体大小
            };
            plotModel.Annotations.Add(positiveEmotionAnnotation);

            // 添加消极情绪标注
            var negativeEmotionAnnotation = new TextAnnotation
            {
                Text = "消极情绪",
                TextPosition = new DataPoint(2, -0.9), // 设置为负坐标的下方
                TextHorizontalAlignment = HorizontalAlignment.Center,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                Stroke = OxyColors.Transparent, // 无边框
                TextColor = OxyColors.Red,      // 消极用红色
                FontWeight = OxyPlot.FontWeights.Bold,
                FontSize = 20 // 调整字体大小
            };
            plotModel.Annotations.Add(negativeEmotionAnnotation);

            // 创建折线图系列
            var lineSeries = new LineSeries
            {
                Title = "情绪变化",
                Color = OxyColors.Red,  // 使用鲜艳的红色
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerFill = OxyColors.Blue,
                StrokeThickness = 2,
                FontSize = 24 // 调整字体大小
            };

            // 添加数据点
            foreach (var data in emotionData)
            {
                lineSeries.Points.Add(new DataPoint(data.Key, data.Value));
            }

            // 将折线图系列添加到模型中
            plotModel.Series.Add(lineSeries);

            // 渲染为 Bitmap
            return new PngExporter { Width = 800, Height = 600 }.ExportToBitmap(plotModel);
        }
    }
}
