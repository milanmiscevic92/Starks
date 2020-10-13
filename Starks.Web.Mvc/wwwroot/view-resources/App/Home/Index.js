$.ajax({
    url: location.origin + "/api/Courses",
    type: "GET",
    success: function (response) {
        if (response != undefined && response.length > 0) {
            var tableContainer = document.getElementById("tableContainer");
            var tableHeadRow = document.getElementById("tableHeadRow");
            var tableBody = document.getElementById("tableBody");

            $.each(response, function (index, value) {
                var thElement = document.createElement("th");
                thElement.setAttribute("scope", "col");
                thElement.innerText = value.name;
                tableHeadRow.appendChild(thElement);

                $.each(value.studentsLink, function (index, value) {
                    var studentRowId = "student-" + value.studentId;
                    var studentRow = document.getElementById(studentRowId);

                    if (!studentRow) {
                        studentRow = document.createElement("tr");
                        studentRow.id = studentRowId;
                        tableBody.appendChild(studentRow);
                    }

                    var studentNameColumnId = "student-name-" + value.studentId;
                    var studentNameColumn = document.getElementById(studentNameColumnId);

                    if (!studentNameColumn) {
                        studentNameColumn = document.createElement("td")
                        studentNameColumn.id = studentNameColumnId;
                        studentNameColumn.innerText = value.student.firstName + " " + value.student.lastName;
                        studentRow.appendChild(studentNameColumn);
                    }

                    var markColumnId = "student-name-" + value.studentId + "-course-" + value.courseId;
                    var markColumn = document.getElementById(markColumnId);

                    if (!markColumn) {
                        markColumn = document.createElement("td");
                        markColumn.id = markColumnId;
                        markColumn.innerText = value.mark;
                        studentRow.appendChild(markColumn);
                    }
                });
            });

            if (tableContainer.hidden == true) {
                tableContainer.hidden = false;
            }
        }
    }
});

async function addCourse() {
    var model = {
        code: document.getElementById("courseCode").value,
        name: document.getElementById("courseName").value,
        description: document.getElementById("courseDescription").value,
    };

    $.ajax({
        url: location.origin + "/api/Courses",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json",
        success: function (response) {

            var tableContainer = document.getElementById("tableContainer");
            var tableHeadRow = document.getElementById("tableHeadRow");
            var thElement = document.createElement("th");
            thElement.setAttribute("scope", "col");
            thElement.innerText = response.name;
            tableHeadRow.appendChild(thElement);

            if (tableContainer.hidden == true) {
                tableContainer.hidden = false;
            }

            document.getElementById("courseCode").value = null;
            document.getElementById("courseName").value = null;
            document.getElementById("courseDescription").value = null;
        }
    });
};

function addStudent() {
    var model = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        address: document.getElementById("address").value,
        city: document.getElementById("city").value,
        state: document.getElementById("state").value,
        dateOfBirth: document.getElementById("dateOfBirth").value
    };

    $.ajax({
        url: location.origin + "/api/Students",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json",
        success: function (response) {

            var studentRowId = "student-" + response.id;
            var studentRow = document.getElementById(studentRowId);

            if (!studentRow) {
                studentRow = document.createElement("tr");
                studentRow.id = studentRowId;
                tableBody.appendChild(studentRow);
            }

            var studentNameColumnId = "student-name-" + response.id;
            var studentNameColumn = document.getElementById(studentNameColumnId);

            if (!studentNameColumn) {
                studentNameColumn = document.createElement("td")
                studentNameColumn.id = studentNameColumnId;
                studentNameColumn.innerText = response.firstName + " " + response.lastName;
                studentRow.appendChild(studentNameColumn);
            }

            $.each(response.coursesLink, function (index, value) {
                var markColumnId = "student-name-" + value.studentId + "-course-" + value.courseId;
                var markColumn = document.getElementById(markColumnId);

                if (!markColumn) {
                    markColumn = document.createElement("td");
                    markColumn.id = markColumnId;
                    markColumn.innerText = value.mark;
                    studentRow.appendChild(markColumn);
                }
            });

            document.getElementById("firstName").value = "";
            document.getElementById("lastName").value = null;
            document.getElementById("address").value = null;
            document.getElementById("city").value = null;
            document.getElementById("state").value = null;
            document.getElementById("dateOfBirth").value = null;
        }
    });
};

window.onload = function (e) {
    var addStudentButton = document.getElementById("addStudentButton");
    var addCourseButton = document.getElementById("addCourseButton");

    addStudentButton.addEventListener("click", function () {
        addStudent();
    });

    addCourseButton.addEventListener("click", function () {
        addCourse();
    });
}