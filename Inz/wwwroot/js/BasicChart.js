var chartData = {
    labels: ['Nowe Wizyty', 'Do Zatwierdzenia', 'Zakończone'],
    datasets: [{
        label: 'Liczba Wizyt',
        data: [
            document.getElementById('myChart').dataset.newVisits,
            document.getElementById('myChart').dataset.visitsToApprove,
            document.getElementById('myChart').dataset.finishedVisit
        ],
        backgroundColor: ['rgb(255, 99, 132)', 'rgb(54, 162, 235)', 'rgb(255, 205, 86)'],
        hoverOffset: 4
    }]
};

var ctx = document.getElementById('myChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'doughnut',
    data: chartData,
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

