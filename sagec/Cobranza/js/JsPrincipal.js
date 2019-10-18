var principal = (function(principal, undefined) {

    _grafico01 = function() {

            Highcharts.chart('grafico01', {

                chart: {
                    type: 'column'
                },

                title: {
                    text: 'Total fruit consumtion, grouped by gender'
                },

                xAxis: {
                    categories: ['Apples', 'Oranges', 'Pears', 'Grapes', 'Bananas']
                },

                yAxis: {
                    allowDecimals: false,
                    min: 0,
                    title: {
                        text: 'Number of fruits'
                    }
                },

                tooltip: {
                    formatter: function() {
                        return '<b>' + this.x + '</b><br/>' +
                            this.series.name + ': ' + this.y + '<br/>' +
                            'Total: ' + this.point.stackTotal;
                    }
                },

                plotOptions: {
                    column: {
                        stacking: 'normal'
                    }
                },

                series: [{
                    name: 'John',
                    data: [5, 3, 4, 7, 2],
                    stack: 'male'
                }, {
                    name: 'Joe',
                    data: [3, 4, 4, 2, 5],
                    stack: 'male'
                }, {
                    name: 'Jane',
                    data: [2, 5, 6, 2, 1],
                    stack: 'female'
                }, {
                    name: 'Janet',
                    data: [3, 0, 4, 4, 3],
                    stack: 'female'
                }]
            });
        },
        _grafico02 = function() {
            Highcharts.chart('grafico02', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'World\'s largest cities per 2014'
                },
                subtitle: {
                    text: 'Source: <a href="http://en.wikipedia.org/wiki/List_of_cities_proper_by_population">Wikipedia</a>'
                },
                xAxis: {
                    type: 'category',
                    labels: {
                        rotation: -45,
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Population (millions)'
                    }
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: 'Population in 2008: <b>{point.y:.1f} millions</b>'
                },
                series: [{
                    name: 'Population',
                    data: [
                        ['Shanghai', 23.7],
                        ['Lagos', 16.1],
                        ['Istanbul', 14.2],
                        ['Karachi', 14.0],
                        ['Mumbai', 12.5],
                        ['Moscow', 12.1],
                        ['São Paulo', 11.8],
                        ['Beijing', 11.7],
                        ['Guangzhou', 11.1],
                        ['Delhi', 11.1],
                        ['Shenzhen', 10.5],
                        ['Seoul', 10.4],
                        ['Jakarta', 10.0],
                        ['Kinshasa', 9.3],
                        ['Tianjin', 9.3],
                        ['Tokyo', 9.0],
                        ['Cairo', 8.9],
                        ['Dhaka', 8.9],
                        ['Mexico City', 8.9],
                        ['Lima', 8.9]
                    ],
                    dataLabels: {
                        enabled: true,
                        rotation: -90,
                        color: '#FFFFFF',
                        align: 'right',
                        format: '{point.y:.1f}', // one decimal
                        y: 10, // 10 pixels down from the top
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                }]
            });
        },
        _grafico03 = function() {
            Highcharts.chart('grafico03', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Browser market shares January, 2015 to May, 2015'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: [{
                        name: 'IE',
                        y: 56.33
                    }, {
                        name: 'Chrome',
                        y: 24.03,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Firefox',
                        y: 10.38
                    }, {
                        name: 'Safari',
                        y: 4.77
                    }, {
                        name: 'Opera',
                        y: 0.91
                    }, {
                        name: 'Other',
                        y: 0.2
                    }]
                }]
            });
        };
    principal.grafico04 = function() {
            Highcharts.chart('grafico04', {

                chart: {
                    type: 'heatmap',
                    marginTop: 40,
                    marginBottom: 80,
                    plotBorderWidth: 1
                },


                title: {
                    text: 'Sales per employee per weekday'
                },

                xAxis: {
                    categories: ['Alexander', 'Marie', 'Maximilian', 'Sophia', 'Lukas', 'Maria', 'Leon', 'Anna', 'Tim', 'Laura']
                },

                yAxis: {
                    categories: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
                    title: null
                },

                colorAxis: {
                    min: 0,
                    minColor: '#FFFFFF',
                    maxColor: Highcharts.getOptions().colors[0]
                },

                legend: {
                    align: 'right',
                    layout: 'vertical',
                    margin: 0,
                    verticalAlign: 'top',
                    y: 25,
                    symbolHeight: 280
                },

                tooltip: {
                    formatter: function() {
                        return '<b>' + this.series.xAxis.categories[this.point.x] + '</b> sold <br><b>' +
                            this.point.value + '</b> items on <br><b>' + this.series.yAxis.categories[this.point.y] + '</b>';
                    }
                },

                series: [{
                    name: 'Sales per employee',
                    borderWidth: 1,
                    data: [
                        [0, 0, 10],
                        [0, 1, 19],
                        [0, 2, 8],
                        [0, 3, 24],
                        [0, 4, 67],
                        [1, 0, 92],
                        [1, 1, 58],
                        [1, 2, 78],
                        [1, 3, 117],
                        [1, 4, 48],
                        [2, 0, 35],
                        [2, 1, 15],
                        [2, 2, 123],
                        [2, 3, 64],
                        [2, 4, 52],
                        [3, 0, 72],
                        [3, 1, 132],
                        [3, 2, 114],
                        [3, 3, 19],
                        [3, 4, 16],
                        [4, 0, 38],
                        [4, 1, 5],
                        [4, 2, 8],
                        [4, 3, 117],
                        [4, 4, 115],
                        [5, 0, 88],
                        [5, 1, 32],
                        [5, 2, 12],
                        [5, 3, 6],
                        [5, 4, 120],
                        [6, 0, 13],
                        [6, 1, 44],
                        [6, 2, 88],
                        [6, 3, 98],
                        [6, 4, 96],
                        [7, 0, 31],
                        [7, 1, 1],
                        [7, 2, 82],
                        [7, 3, 32],
                        [7, 4, 30],
                        [8, 0, 85],
                        [8, 1, 97],
                        [8, 2, 123],
                        [8, 3, 64],
                        [8, 4, 84],
                        [9, 0, 47],
                        [9, 1, 114],
                        [9, 2, 31],
                        [9, 3, 48],
                        [9, 4, 91]
                    ],
                    dataLabels: {
                        enabled: true,
                        color: '#000000'
                    }
                }]

            });
        },
        principal.pieChartsGrafics = function() {
            // TOTAL REPORTANDO

            $('#pie_chart_1').easyPieChart({
                barColor: '#ea553d',
                lineWidth: 5,
                animate: 3000,
                size: 65,
                lineCap: 'square',
                scaleColor: 'rgba(33,33,33,.1)',
                trackColor: '#f2f2f2',
                onStep: function(from, to, percent) {
                    $(this.el).find('.percent').text(Math.round(percent));
                }
            });

        };


    return principal;

})(principal || {});

$(function() {
    principal.grafico04();
    principal.pieChartsGrafics();

});