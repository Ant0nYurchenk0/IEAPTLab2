const uri = 'https://localhost:7210/api/seasons';
let seasons = [];

function getSeasons() {
    fetch(uri, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })

        .then(response => response.json())
        .then(data => _displaySeasons(data))
        .catch(error => console.error('Unable to get seasons.', error));
}

function addSeason() {
    const addNameTextbox = document.getElementById('add-name');
    const addStartTextbox = document.getElementById('add-start-date');
    const addEndTextbox = document.getElementById('add-end-date');
    const addInfoTextbox = document.getElementById('add-description');

    const season = {
        name: addNameTextbox.value.trim(),
        startDate: addStartTextbox.value.trim(),
        endDate: addEndTextbox.value.trim(),
        description: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(season)
    })
        .then(response => response.json())
        .then(() => {
            getSeasons();
            addNameTextbox.value = '';
            addStartTextbox.value = '';
            addEndTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add season.', error));
}

function deleteSeason(id) {
    fetch(`${uri}/?id=${id}`, {
        method: 'DELETE'
    })
        .then(() => getSeasons())
        .catch(error => console.error('Unable to delete season.', error));
}

function displayEditForm(id) {
    const season = seasons.find(season => season.id === id);

    document.getElementById('edit-id').value = season.id;
    document.getElementById('edit-name').value = season.name;
    document.getElementById('edit-start-date').value = season.startDate;
    document.getElementById('edit-end-date').value = season.endDate;
    document.getElementById('edit-description').value = season.description;
    document.getElementById('editForm').style.display = 'block';
}

function updateSeason() {
    const seasonId = document.getElementById('edit-id').value;
    const season = {
        id: parseInt(seasonId, 10),
        name: document.getElementById('edit-name').value.trim(),
        startDate: document.getElementById('edit-start-date').value.trim(),
        endDate: document.getElementById('edit-end-date').value.trim(),
        description: document.getElementById('edit-description').value.trim()
    };

    fetch(uri, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(season)
    })
        .then(() => getSeasons())
        .catch(error => console.error('Unable to update season.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displaySeasons(data) {
    const tBody = document.getElementById('seasons');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(season => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.classList.add("btn");
        editButton.classList.add("btn-warning");
        editButton.setAttribute('onclick', `displayEditForm(${season.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.classList.add("btn");
        deleteButton.classList.add("btn-danger");
        deleteButton.setAttribute('onclick', `deleteSeason(${season.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(season.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
         textNode = document.createTextNode(season.startDate);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
         textNode = document.createTextNode(season.endDate);
        td3.appendChild(textNode);

        let td4 = tr.insertCell(3);
        let textNodeInfo = document.createTextNode(season.description);
        td4.appendChild(textNodeInfo);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    seasons = data;
}
