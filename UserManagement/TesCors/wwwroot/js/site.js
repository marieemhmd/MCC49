////const judul = document.getElementById("judul");
////judul.style.color = "green";
////judul.innerHTML = "ini saya rubah"

//const judul = document.querySelector("#judul");
//const li = document.querySelector("li:nth-child(3)");
//judul.style.backgroundColor = "orange";
//li.style.backgroundColor = "cyan";

//const p = document.querySelectorAll("p"); //query selector all dikasih index
//for (let i = 0; i < p.length; i++) {
//    p[i].style.backgroundColor = "cyan";
//}
////p[1].style.backgroundColor = "cyan";
//console.log(p);

//const list = document.getElementsByClassName("list");
//list[2].innerHTML = "ubah"; //index mulai dari 0

//const p4 = document.querySelector(".b p");
//console.log(p4.getAttribute("id"));

//p4.setAttribute("class", "warna");

function ChangeColorRed() {
    document.body.style.background = 'red';
}

function ChangeColorWhite() {
    document.body.style.background = 'white';
}

function CenterText() {
    const judul = document.getElementById("judul");
    judul.style.textAlign = 'center';

}

$('.btnBg').click(function () {
    ChangeColorRed();
})

$('#iniatribut').click(function () {
    $('body').css('background-color', 'lightgreen');
    $('#iniatribut').html('ubah isinya');
})


const buttonBackground = document.querySelector('.btnBg');
const linkBtn = document.querySelector('.linkBtn');

//linkBtn.addEventListener('click', function (e) {
//    e.preventDefault;
//    ChangeColor();
//})

//buttonBackground.onClick = function () {
//    document.body.style.color = "yellow";
//}

//buttonBackground.onClick = ChangeColor;

//buttonBackground.addEventListener("mouseover", function () {
//    document.body.style.background = "cyan";
//})

//buttonBackground.addEventListener("mouseleave", function () {
//    document.body.style.background = "red";
//})

//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/"

//}).done((result) => {
//    //console.log(result.results[0]);
//    var text = "";
//    $.each(result.results, function (key, val) { //literal template js
//        text += `<tr>
//                   <td>${val.name}</td>        
//                   <td><button type="button" class="btn btn-primary" data-toggle="modal" onclick="detail('${val.url}')" data-target="#exampleModal"> Detail </button></td>      
//                </tr>` //data-body="${val.url}"
//    });

//    $(".tableSW").html(text);
//}).fail((error) => {
//    console.log(error);
//});

//$("#btnDetail").on("Click", function () {
//    var url = $("#btnDetail").data("url");
//    console.log(url);
//})

//function detail(stringURL) {
//    $.ajax({
//        url: stringURL 
//    }).done((result) => {
//        //console.log(result);
//        text = `<img src="${result.sprites.front_default}">
//                <p>Nama : ${result.name}</p>
//                <p>Jurus : ${result.moves[0].move.name}</p>
//                <p>Tinggi : ${result.height} cm</p>
//                <p>Berat : ${result.weight} kg</p>
//                `
//        title = `<h5>Biodata ${result.name}</h5>`

//        $(".modal-body").html(text);
//        $(".modal-title").html(title);
//    }).fail((error) => {
//        console.log(error);
//    });
//}

//function CheckPassword(inputtxt) {
//    var passw = /^[A-Za-z\d]\w{8,}$/;
//    if (inputtxt.value.match(passw)) {
//        alert('Correct, try another...')
//        return true;
//    }
//    else {
//        alert('Wrong...!')
//        return false;
//    }
//}
function detail(stringURL) {
    $.ajax({
        url: stringURL 
    }).done((result) => {
        //console.log(result);
        text = `<img src="${result.sprites.front_default}">
                <p>Nama : ${result.name}</p>
                <p>Jurus : ${result.moves[0].move.name}</p>
                <p>Tinggi : ${result.height} cm</p>
                <p>Berat : ${result.weight} kg</p>
                `
        title = `<h5>Biodata ${result.name}</h5>`

        $(".modal-body").html(text);
        $(".modal-title").html(title);
    }).fail((error) => {
        console.log(error);
    });
}

function findPerson(PersonId) {
    //var nik = "";
    console.log(PersonId);
    $.ajax({
        url: "https://localhost:44363/api/Accounts/Profile/" + PersonId + "/"
        //type: "PUT"
    }).done((result) => {
        //alert("Data Successfully Removed !");
        //$("#myTable").DataTable().ajax.reload();
        
        
        nik = `<label for="NIK">Nomor Induk Kependudukan</label>
               <input type="text" class="form-control" id="editNIK" placeholder="NIK" value="${result[0].nik}" readonly>`
        fname = `<label for="FirstName">First Name</label>
                <input type="text" class="form-control" value="${result[0].firstName}" name="fName" id="editFirstName" placeholder="First Name" pattern="(?=.*[A-Za-z]).{3,}" title="Must contain at least 3 or more characters" required>`
        lname = `<label for="Last Name">Last Name</label>
                 <input type="text" class="form-control" id="editLastName" value="${result[0].lastName}" name="lName" placeholder="Last Name" pattern="(?=.*[A-Za-z]).{3,}" title="Must contain at least 3 or more characters" required>`
        phone = `<label for="Phone">Phone</label>
                 <input type="text" class="form-control" id="editPhone" value="${result[0].phone}" placeholder="Phone" required>`
        birthday = `<label for="BirthDate">Birth Date</label>
                    <input type="date" class="form-control" id="editBirthDate" value="${result[0].birthDate.slice(0,10)}" placeholder="Birth Date" required>`
        salary = `<label for="Salary">Salary</label>
                  <input type="number" class="form-control" id="editSalary" value="${result[0].salary}" placeholder="Salary" required>`
        email = `<label for="Email">Email address</label>
                 <input type="email" class="form-control" id="editEmail" value="${result[0].email}" aria-describedby="emailHelp" placeholder="Enter email" name="email1" required>`
        educationId = `<label for="EducationId">Education Id</label>
                       <input type="number" class="form-control" id="editEducationId" value="${result[0].educationId}" placeholder="Education Id" required>`
        degree =    `<label for="Degree">Degree</label>
                    <select name="degree" id="editDegree" class="form-control" required>
                        <option value="${result[0].degree}" hidden>${result[0].degree}</option>
                        <option value="S1">S1</option>
                        <option value="S2">S2</option>
                        <option value="S3">S3</option>
                    </select>`
        gpa = `<label for="GPA">GPA</label>
               <input type="text" class="form-control" id="editGPA" value="${result[0].gpa}" placeholder="GPA" required>`
        university =    `<label for="UniversityId">University</label>
                        <select name="university" id="editUniversity" class="form-control" required>
                            <option value="${result[0].universityId}" hidden>${result[0].university}</option>
                            <option value=1>ITS</option>
                            <option value=2>ITB</option>
                            <option value=3>UGM</option>
                            <option value=4>UI</option>
                            <option value=5>USU</option>
                        </select>`
        $(".nik").html(nik);
        $(".fname").html(fname);
        $(".lname").html(lname);
        $(".phone").html(phone);
        $(".birthday").html(birthday);
        $(".salary").html(salary);
        $(".email").html(email);
        $(".educationId").html(educationId);
        $(".degree").html(degree);
        $(".gpa").html(gpa);
        $(".university").html(university);

        //console.log(result[0].nik);
        ////txt = '<button type="button" class="btn btn-primary" data-dismiss="modal" onclick="deletePerson(' + "'" + PersonId + "'" + ')">Yes</button><button type="button" class="btn btn-danger" data-dismiss="modal">No</button>'
    }).fail((error) => {
        alert("error");
    });
}

function Update(FirstName, LastName) {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.NIK = $('#editNIK').val();
    obj.FirstName = $('#editFirstName').val();
    obj.LastName = $('#editLastName').val();
    obj.Phone = $('#editPhone').val();
    obj.BirthDate = $('#editBirthDate').val();
    obj.Salary = $('#editSalary').val();
    obj.Email = $('#editEmail').val();
    //obj.Password = $('#editPassword').val();
    //obj.Degree = $('#editDegree').val();
    //obj.GPA = $('#edittGPA').val();
    //obj.UniversityId = $('#InputUniversity').val();
    var name = /^[A-Za-z]\w{2,}$/;
    if (FirstName.value.match(name)) {
        if (LastName.value.match(name)) {
            if (obj.NIK == "" || obj.FirstName == "" || obj.LastName == "" || obj.Phone == "" || obj.BirthDate == "" || obj.Salary == "" || obj.Email == "") {
                alert("Data can't be empty !");
            }
            else {
                $.ajax({
                    type: "PUT",
                    url: "https://localhost:44363/api/Persons/",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json"
                }).done((result) => {
                    //buat alert pemberitahuan jika success
                    //alert("Person Successfully Update!");
                    Swal.fire(
                        'Good job!',
                        'Data successfully updated !',
                        'success'
                    );
                    $("#myTable").DataTable().ajax.reload();
                }).fail((error) => {
                    //alert pemberitahuan jika gagal
                    //alert("Error occured !");
                });

            }
            var edu = new Object();
            edu.Id = $('#editEducationId').val();
            edu.Degree = $('#editDegree').val();
            edu.GPA = $('#editGPA').val();
            edu.UniversityId = $('#editUniversity').val();
            if (edu.Id == "" || edu.Degree == "" || edu.GPA == "" || edu.UniversityId == "") {
                alert("Data can't be empty !");
            }
            else {
                $.ajax({
                    type: "PUT",
                    url: "https://localhost:44363/api/Educations/",
                    data: JSON.stringify(edu),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json"
                }).done((result) => {
                    //buat alert pemberitahuan jika success
                    //alert("Education Successfully Update!");
                    
                    $("#myTable").DataTable().ajax.reload();
                }).fail((error) => {
                    //alert pemberitahuan jika gagal
                    //alert("Error occured !");
                });

            }
        }
        else {
            alert("Last Name must contain at least 3 or more characters !");
        }

    } else {
        alert("First Name must contain at least 3 or more characters !");
    }

    //alert('Correct, try another...')
    //return true;
}


function findDelPerson(PersonId, EduId) {
    var txt = "";
    txt = '<button type="button" class="btn btn-primary" data-dismiss="modal" onclick="deletePerson(' + "'" + PersonId + "'" + "," + "'" + EduId + "'" + ')">Yes</button><button type="button" class="btn btn-danger" data-dismiss="modal">No</button>'
    $(".delBtn").html(txt);
    console.log(PersonId);
    console.log(EduId);
}

function deletePerson(IdNumber, IdEducation) {
    console.log(IdNumber);
    console.log(IdEducation);
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44363/api/Persons/" + IdNumber + "/",
        contentType: "application/json; charset=utf-8",
        datatype: "json"
    }).done((result) => {
        //alert("Data Successfully Removed !");
        //$("#myTable").DataTable().ajax.reload();
    }).fail((error) => {
        alert("error");
    });

    $.ajax({
        type: "DELETE",
        url: "https://localhost:44363/api/Educations/" + IdEducation + "/",
        contentType: "application/json; charset=utf-8",
        datatype: "json"
    }).done((result) => {
        alert("Data Successfully Removed !");
        $("#myTable").DataTable().ajax.reload();
    }).fail((error) => {
        alert("error");
    });
}

function myFunction() {
    var x = document.getElementById("InputPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
//function ajaxpost() {
//    return false;
//}

function Insert(inputtxt, inputEmail) {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.NIK = $('#InputNIK').val();
    obj.FirstName = $('#InputFirstName').val();
    obj.LastName = $('#InputLastName').val();
    obj.Phone = $('#InputPhone').val();
    obj.BirthDate = $('#InputBirthDate').val();
    obj.Salary = $('#InputSalary').val();
    obj.Email = $('#InputEmail').val();
    obj.Password = $('#InputPassword').val();
    obj.Degree = $('#InputDegree').val();
    obj.GPA = $('#InputGPA').val();
    obj.UniversityId = $('#InputUniversity').val();
    var email = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var passw = /^[A-Za-z\d]\w{8,}$/;
    if (inputEmail.value.match(email)) {
        if (inputtxt.value.match(passw)) {
            if (obj.NIK == "" || obj.FirstName == "" || obj.LastName == "" || obj.Phone == "" || obj.BirthDate == "" || obj.Salary == "" || obj.Email == "" || obj.Password == "" || obj.Degree == "" || obj.GPA == "" || obj.UniversityId == "") {
                return false;
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "https://localhost:44363/api/Accounts/Register/",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json"
            }).done((result) => {
            //buat alert pemberitahuan jika success
                    alert("Data Successfully Added !");
                    $("#myTable").DataTable().ajax.reload();
            }).fail((error) => {
                //alert pemberitahuan jika gagal
                //alert("Error occured !");
            });

            }
            //alert('Correct, try another...')
            //return true;
        }
    }
}

$(document).ready(function () {

    var table = $('#myTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        "ajax": {
            //"url": "https://localhost:44363/api/Accounts/UserData/",
            "url": "/Accounts/GetUserData/",
            
            "datatype": "json",
            "dataSrc": ''
        },
        "columns": [
            {
                "data": "null", "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "nik" },
            { "data": "firstName" },
            { "data": "lastName" },
            {
                "data": "phone", "render": function (data, type, row) {
                    return '+62' + data.slice(1);
                }
            },
            {
                "data": "null", "sortable": false, "render": function (data, type, row, meta) {
                    return "<button type='button' class='btn' data-toggle='modal' data-target='#exampleModal'><i class='fa fa-info-circle'></i></button><span> </span><button type='button' class='btn' data-toggle='modal' data-target='#editModal' onclick='findPerson(" + '"' + row.nik + '"' + ")'><i class='fa fa-edit'></i></button><span> </span><button type='button' class='btn' data-toggle='modal' data-target='#deleteModal' onclick='findDelPerson(" + '"' + row.nik + '"' + "," + '"' + row.educationId + '"' + ")'><i class='fa fa-trash'></i></button>";
                }
            }
        ],
        "columnDefs": [{
            "searchable": false,
            "orderable": false,
            "targets": 0
        }],
        
    });

    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
        
});



    //console.log(result.results[0]);
    //var text = "";
    //$.each(result.results, function (key, val) { //literal template js
    //    text += `<tr>
    //               <td>${val.name}</td>      
    //               <td>${val.gender}</td>      
    //               <td>${val.height} cm</td>      
    //               <td><button type="button" class="btn btn-primary" data-toggle="modal" data-body="" onclick="detail('${val.url}')" data-target="#exampleModal"> Detail </button></td>      
    //            </tr>`
    //});
    //$(".tableSW").html(text);
    //$("#exampleModal");



//$.ajax({
//    url: "https://swapi.dev/api/people/1/",
//    success: ,
//    fail: 
//})
//public class Object {
//    public string NIK;
//    public string FirstName;
//    public string LastName;
//    public string Phone;
//    public DateTime BirthDate;
//    public int Salary;
//    public string Email;
//    public string Password;
//    public string Degree;
//    public string GPA;
//    public int UniversityId;
//    public string Role;
//}