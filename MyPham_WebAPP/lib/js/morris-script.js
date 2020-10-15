var Script = function () {

    //morris chart

    $(function () {
      // data stolen from http://howmanyleft.co.uk/vehicle/jaguar_'e'_type
      var tax_data = [
           {"period": "2019 Q3", "Doanh thu": 73463000, "Lợi nhuận": 33266000},
           {"period": "2019 Q2", "Doanh thu": 73512000, "Lợi nhuận": 35129000},
           {"period": "2019 Q1", "Doanh thu": 82691000, "Lợi nhuận": 51282000},
           {"period": "2018 Q4", "Doanh thu": 93246000, "Lợi nhuận": 66311000},
           {"period": "2018 Q3", "Doanh thu": 53171000, "Lợi nhuận": 27468000},
           {"period": "2018 Q2", "Doanh thu": 33155000, "Lợi nhuận": 18159000},
           {"period": "2018 Q1", "Doanh thu": 32262000, "Lợi nhuận": 16820000}
      ];
      Morris.Line({
        element: 'hero-graph',
        data: tax_data,
        xkey: 'period',
        ykeys: ['Doanh thu', 'Lợi nhuận'],
        labels: ['Doanh thu', 'Lợi nhuận'],
        lineColors:['#8075c4','#b22222']
      });

      Morris.Bar({
        element: 'hero-bar',
        data: [
          {device: 'Tháng 1', geekbench: 136},
          {device: 'Tháng 2', geekbench: 244},
          {device: 'Tháng 3', geekbench: 175},
          {device: 'Tháng 4', geekbench: 80},
          {device: 'Tháng 5', geekbench: 105}
        ],
        xkey: 'device',
        ykeys: ['geekbench'],
        labels: ['Đơn Hàng'],
        barRatio: 0.4,
        xLabelAngle: 0,
        hideHover: 'auto',
        barColors: ['#6883a3']
      });

      
      $('.code-example').each(function (index, el) {
        eval($(el).text());
      });
    });

}();




