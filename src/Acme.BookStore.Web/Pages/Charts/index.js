var chartDom = document.getElementById('main');
var myChart = echarts.init(chartDom);
var option;

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
            data: [120, 200, 150, 80, 70, 110, 130],
            type: 'bar',
            showBackground: true,
            backgroundStyle: {
                color: 'rgba(180, 180, 180, 0.2)'
            }
        }
    ]
};

option && myChart.setOption(option);

// 버튼 클릭 시 ChartData API 출력
const button = document.getElementById('checkData');

button.addEventListener('click', function () {
    // AJAX GET 요청을 보내는 함수
    function fetchData() {
        $.ajax({
            type: "GET",
            url: '/api/app/data-chart/random-numbers',
            success: function (data) {
                // 요청이 성공하면 반환된 데이터를 처리합니다.
                let target = option.series[0].data;
                target.forEach((element, index, array) => {
                    array[index] = data[index]
                }); 
                option && myChart.setOption(option);

            },
            error: function (err) {
                // 요청이 실패한 경우 에러 처리를 수행합니다.
                console.error('데이터 가져오기 실패:', err);
            }
        });
    }

    // 페이지 로드 시 데이터 가져오기 함수 호출
    fetchData();
});