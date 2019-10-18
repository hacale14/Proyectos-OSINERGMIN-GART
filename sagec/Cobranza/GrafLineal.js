$(document).ready(function () {
// prepare chart data as an array
var sampleData = [
{ Day: '01', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '02', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '03', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '04', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '05', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '06', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '07', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '08', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '09', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '10', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '11', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '12', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '13', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '14', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '15', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '16', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '17', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '18', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '19', 201707: 1000,  Cycling: 25, Goal: 40 },
{ Day: '20', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '21', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '22', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '23', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '24', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '25', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '26', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '27', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '28', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '29', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '30', 201707: 0,  Cycling: 25, Goal: 40 },
{ Day: '31', 201707: 0,  Cycling: 25, Goal: 40 }
];

// prepare jqxChart settings
var settings = {
title: 'REPORTE POR PERIODO',
description: 'Evalucion por dia de dos periodos',
enableAnimations: true,
showLegend: true,
padding: { left: 10, top: 10, right: 15, bottom: 20 },
titlePadding: { left: 90, top: 0, right: 0, bottom: 20 },
source: sampleData,
colorScheme: 'scheme05',
xAxis: {
dataField: 'Day',
unitInterval: 1,
tickMarks: { visible: true, interval: 1 },
gridLinesInterval: { visible: true, interval: 1 },
valuesOnTicks: false,
padding: { bottom: 10 }
},
valueAxis: {
unitInterval: 1000,
minValue: 0,
maxValue: 1001,
title: { text: 'Por Periodo de Dias<br><br>' },
labels: { horizontalAlignment: 'right' }
},
seriesGroups:
[
{
type: 'line',
series:
[
{
dataField: '201707',
symbolType: 'square',

labels:
{
visible: false,
backgroundColor: '#FEFEFE',
backgroundOpacity: 0.2,
borderColor: '#7FC4EF',
borderOpacity: 0.7,
padding: { left: 5, right: 5, top: 0, bottom: 20 }
}
}

]
}
]
};

// setup the chart
$('#jqxChart').jqxChart(settings);

});
