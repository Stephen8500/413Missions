/*function for calculating grade:*/
$('#btnCalc').click(function () {
    /*get values from form, round to two decimal places*/
    let assignPct = Math.round(($('#assignScore').val() * .55) * 100) / 100
    let grpPrjtPct = Math.round(($('#grpPrjtScore').val() * .05) * 100) / 100
    let quizPct = Math.round(($('#quizScore').val() * .1) * 100) / 100
    let examPct = Math.round(($('#examScore').val() * .2) * 100) / 100
    let intexPct = Math.round(($('#intexScore').val() * .1) * 100) / 100

    /*calculate overall course score out of 100, assign letter grade*/
    overallScore = (assignPct + grpPrjtPct + quizPct + examPct + intexPct)
    letterGrade = ''
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

    /*change value of html p tag with id output to reflect calculated course grade and letter grade*/
    $('#output').text('Overall grade: ' + overallScore + '%, Letter grade: ' + letterGrade)
})