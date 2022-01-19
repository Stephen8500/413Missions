/// function for loading message on page load:
window.onload = function () {
    if (sessionStorage.getItem('message')) {
        let message = sessionStorage.getItem('message')
        sessionStorage.removeItem('message')
        $('#output').text(message)
    }
};
/*function for calculating grade:*/
$('#btnCalc').click(function () {
    /*get values from form, round to two decimal places*/
    let assignPct = Math.round(($('#assignScore').val() * .55) * 100) / 100
    let grpPrjtPct = Math.round(($('#grpPrjtScore').val() * .05) * 100) / 100
    let quizPct = Math.round(($('#quizScore').val() * .1) * 100) / 100
    let examPct = Math.round(($('#examScore').val() * .2) * 100) / 100
    let intexPct = Math.round(($('#intexScore').val() * .1) * 100) / 100

    /*calculate overall course score out of 100, assign letter grade*/
    let overallScore = (assignPct + grpPrjtPct + quizPct + examPct + intexPct)
    let letterGrade = ''
    if (overallScore >= 94) {
        letterGrade = 'A' 
    } else if (overallScore >= 90) {
        letterGrade = 'A-'
    } else if (overallScore >= 87) {
        letterGrade = 'B+'
    } else if (overallScore >= 84) {
        letterGrade = 'B'
    } else if (overallScore >= 80) {
        letterGrade = 'B-'
    } else if (overallScore >= 77) {
        letterGrade = 'C+'
    } else if (overallScore >= 74) {
        letterGrade = 'C'
    } else if (overallScore >= 70) {
        letterGrade = 'C-'
    } else if (overallScore >= 67) {
        letterGrade = 'D+'
    } else if (overallScore >= 64) {
        letterGrade = 'D'
    } else if (overallScore >= 60) {
        letterGrade = 'D-'
    } else {
        letterGrade = 'E'
    }

    let message = 'Overall grade: ' + overallScore + '%, Letter grade: ' + letterGrade

    /*change value of html p tag with id output to reflect calculated course grade and letter grade*/
    sessionStorage.setItem('message', message)
})