const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:5001/hub/gameManagerHub")
    .build();
async function start(){
    try {
        await connection.start();
        console.log("SignalR Connected")
    }
    catch (err){
        console.log(err);
        setTimeout(start,5000);
    }
}

connection.onclose(start);
let roomId = null;

connection.on("SendOutHand", cards => {
    console.log(cards);
})

connection.on("JoinedRoom", playerName => {
    console.log(`${playerName} joined the room`);
})

connection.on("GroupId", id => {
    console.log(`Room Name : ${id}`)
    roomId = id;
    const field = document.getElementById("roomIdField");
    field.innerText = roomId;
})

async function joinRoom(event){
    event?.preventDefault();
    const val = document.getElementById("roomId").valueOf();
    let roomId = '00000000-0000-0000-0000-000000000000';
    if (val?.length > 0){
        roomId = val;
    }
    await connection.invoke("JoinRoom", roomId, `Omer`);
}

start();