$(document).ready(function () {
    drawChart();
});

// 버튼 클릭 시 ChartData API 출력
const button = document.getElementById('checkData');
button.addEventListener('click', function () {
    // AJAX GET 요청을 보내는 함수
    function fetchData() {
        $.ajax({
            type: "GET",
            url: '/api/app/data-chart/random-numbers',
            success: function (data) {
                // 차트 새로고침
                refreshChart(data.number);
            },
            error: function (err) {
                // 요청실패시 에러 처리
                console.error('데이터 가져오기 실패:', err);
            }
        });
    }
    // 페이지 로드시 데이터 가져오기 함수 호출
    fetchData();
});

// 버튼 클릭시 텍스트 변환 함수
var btnTextchange = function () {
    document.getElementById("checkData").innerText = "Click more to change more!";
}

// 차트를 그리는 함수
var chartDom = document.getElementById('main');
var myChart = echarts.init(chartDom);
var option;
var seriesData = [120, 200, 150, 80, 70, 110, 130]; //기본값으로 지정한 배열
var drawChart = function () {
    option = {
        xAxis: {
            type: 'category',
            data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
        },
        yAxis: {
            type: 'value'
        },
        series: [
            {
                data: seriesData,
                type: 'bar',
                showBackground: true,
                backgroundStyle: {
                    color: 'rgba(180, 180, 180, 0.2)'
                }
            }
        ]
    };
    option && myChart.setOption(option);
}

//차트를 업데이트 하는 함수
var refreshChart = function (data) {
    option.series[0].data = data;
    option && myChart.setOption(option);
}