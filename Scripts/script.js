const chatbotToggler = document.querySelector(".chatbot-toggler");
const closeBtn = document.querySelector(".close-btn");
const chatbox = document.querySelector(".chatbox");
const chatInput = document.querySelector(".chat-input textarea");
const sendChatBtn = document.querySelector(".chat-input span");
const choiceBtn = document.querySelector(".chat-incoming-choice");


let userMessage = null; // Variable to store user's message
const inputInitHeight = chatInput.scrollHeight;

const createChatLi = (message, className) => {
    // Create a chat <li> element with passed message and className
    const chatLi = document.createElement("li");
    chatLi.classList.add("chat", `${className}`);
    let chatContent = className === "outgoing" ? `<p></p>` : `<span class="material-symbols-outlined">smart_toy</span><p></p>`;
    chatLi.innerHTML = chatContent;
    chatLi.querySelector("p").innerHTML = message;
    return chatLi; // return chat <li> element
}

const populateChatBox = (chatli) => {
    // Create a chat <li> element with passed message and className
    //find sibling with icon
    var sibling = chatbox.lastChild;
    if (sibling != null) {
        sibling.firstChild.classList.add("removeBotIcon");
        sibling.firstChild.classList.remove("material-symbols-outlined");
    }
    chatbox.appendChild((chatli));
}

const getChatbotResponse = (chatLi) => {
    const messageElement = chatLi.querySelector("p");
    responseObj[userMessage.toLowerCase()] == undefined
        ? messageElement.innerHTML = "Please try something else"
        : messageElement.innerHTML = (responseObj[userMessage.toLowerCase()]);
       

    //return responseObj[chatLi] == undefined
    //    ? "Please try something else"
    //    ? "Please try something else"
    //    : responseObj[chatLi];
};
const getChatbotChoiceResponse = (choice, userChoiceMessage) => {
    var messageElement = "";
    responseObj[choice.toLowerCase()] == undefined
        ? messageElement = "Please try something else"
        : messageElement = (responseObj[choice.toLowerCase()]);
    populateChatBox(createChatLi(userChoiceMessage, "outgoing"));
    populateChatBox(createChatLi(messageElement, "incoming"));
};


const handleChat = () => {
    userMessage = chatInput.value.trim(); // Get user entered message and remove extra whitespace
    if(!userMessage) return;

    // Clear the input textarea and set its height to default
    chatInput.value = "";
    chatInput.style.height = `${inputInitHeight}px`;

    // Append the user's message to the chatbox
    chatbox.appendChild(createChatLi(userMessage, "outgoing"));
    chatbox.scrollTo(0, chatbox.scrollHeight);
    
    setTimeout(() => {
        // Display "Thinking..." message while waiting for the response
        const incomingChatLi = createChatLi("Menunggu...", "incoming");
        chatbox.appendChild(incomingChatLi);
        chatbox.scrollTo(0, chatbox.scrollHeight);
        getChatbotResponse(incomingChatLi);
    }, 600);
}


chatInput.addEventListener("input", () => {
    // Adjust the height of the input textarea based on its content
    chatInput.style.height = `${inputInitHeight}px`;
    chatInput.style.height = `${chatInput.scrollHeight}px`;
});

chatInput.addEventListener("keydown", (e) => {
    // If Enter key is pressed without Shift key and the window 
    // width is greater than 800px, handle the chat
    if(e.key === "Enter" && !e.shiftKey && window.innerWidth > 800) {
        e.preventDefault();
        handleChat();
    }
});
function initializeChat() {
    if (chatbox.innerHTML.trim() == "") {
        populateChatBox(createChatLi("Salam Sejahtera <br>Boleh Saya Bantu Anda? <br>", "incoming"));
        populateChatBox(createChatLi("Tekan pilihan dibawah untuk jawapan <br>", "incoming"));
        populateChatBox(createChatLi("<button class='chat-incoming-choice btn btn-primary' onclick='getChatbotChoiceResponse(\"1\",Tekan 1 : Jika ada ingin tahu tentang cara Permohonan)'> Tekan 1 : Jika ada ingin tahu tentang cara Permohonan</span>", "incoming"));
        populateChatBox(createChatLi("Tekan 2 : Jika ingin tahu cara menaik taraf Penguna", "incoming"));
    }
}
sendChatBtn.addEventListener("click", handleChat);
closeBtn.addEventListener("click", () => document.body.classList.remove("show-chatbot"));
chatbotToggler.addEventListener("click", () => {
    document.body.classList.toggle("show-chatbot")
    initializeChat();
});
choiceBtn.addEventListener("click", () => { getChatbotChoiceResponse(this.value) });

