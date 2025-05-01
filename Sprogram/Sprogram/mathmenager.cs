using System;
using System.Collections.Generic;

namespace Sprogram
{

    public class BeamStressCalculator
    {
        private double _moment;
        private double _inertiaMoment;
        private double _minY;
        private double _maxY;
        private double _step;
        List<(double, double)> _stressTable = new List<(double y, double stress)>();

        public double Moment => _moment;
        public double InertiaMoment => _inertiaMoment;
        public double MinY => _minY;
        public double MaxY => _maxY;
        public double Height => _maxY - _minY;

        public void SetParameters(double moment, double inertiaMoment, double minY, double maxY, double step)
        {
            if (inertiaMoment <= 0)
                throw new ArgumentException("МОМЕНТ ИНЕРЦИИ ДОЛЖЕН БЫТЬ БОЛЬШЕ 0!!!");

            if (minY >= maxY)
                throw new ArgumentException("Нижняя граница должна быть меньше верхней!");

            if (step <= 0)
                throw new ArgumentException("Шаг должен быть положительным!");

            _moment = moment;
            _inertiaMoment = inertiaMoment;
            _minY = minY;
            _maxY = maxY;
            _step = step;
            CreateStressTRable();

        }
        
        private void CreateStressTRable()
        {
            var stressTable = new List<(double y, double stress)>();

            // Добавляем начальную точку
            double firstY = _minY;
            stressTable.Add((firstY, CalculateStress(firstY)));
            _stressTable.Add((firstY, CalculateStress(firstY)));


            // Добавляем промежуточные точки
            for (double y = _minY + _step; y < _maxY; y += _step)
            {
                stressTable.Add((y, CalculateStress(y)));
                _stressTable.Add((y, CalculateStress(y)));
            }

            // Добавляем конечную точку (если не совпадает с последней)
            if (_maxY != stressTable.Last().y)
            {
                stressTable.Add((_maxY, CalculateStress(_maxY)));
                _stressTable.Add((_maxY, CalculateStress(_maxY)));
            }

            if (stressTable.Count == 0)
                throw new InvalidOperationException("Не удалось создать таблицу напряжений. Проверьте параметры.");
        }

        public List<(double y, double stress)> GetStressTable()
        {
            return _stressTable;
        }

        public List<(double y, double stress)> GetTable()
        {
            return _stressTable;
        }
        private double CalculateStress(double y)
        {
            if (y < _minY || y > _maxY)
                throw new ArgumentOutOfRangeException(nameof(y), $"y должен быть в диапазоне [{_minY}, {_maxY}]");

            return (_moment * y) / _inertiaMoment;
        }
    }

}