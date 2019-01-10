

// 显示购物车所有订单列表
function displayOrderList(cartData) {
    if (cartData.orderList.length == 0) return;
    // 获取订单根节点
    let cartListNode = document.querySelector('#cartList');

    //获取订单列表数据
    let orderList = cartData.orderList;

    //将订单列表数据置入新节点
    for (const i in orderList) {
        let order = orderList[i];
        let orderNode = (document.querySelector('#orderExample')).cloneNode(true);
        orderNode.id = "order" + order.id;

        // 将订单节点挂接到父节点下
        cartListNode.appendChild(orderNode);


        // 当前订单节点根元素、+号.减号、删除按钮设计data-id属性
        let idAttrNodes = new Array();
        idAttrNodes.push(orderNode);
        idAttrNodes.push(orderNode.querySelector('[data-operator="increase"]'));
        idAttrNodes.push(orderNode.querySelector('[data-operator="decrease"]'));
        idAttrNodes.push(orderNode.querySelector('[data-operator="deleteItem"]'));
        idAttrNodes.push(orderNode.querySelector('[ data-operator="checkItem"]'));
        idAttrNodes.forEach(element => { element.setAttribute("data-id", order.id); });

        // 为选择框设置状态        
        let checkbox = orderNode.querySelector('[ data-operator="checkItem"]');
        checkbox.checked = order.selectStatus;
        //为小计设置值
        let subQtyNode = orderNode.querySelector('[data-name="subPrice"]');
        subQtyNode.textContent = (order.qty * order.price).toFixed(2);

        //将当前订单呈现到到页面对应节点中
        for (const key in order) {
            if (order.hasOwnProperty(key)) {
                let qstr = '[data-name="' + key + '"]';
                let elementNode = orderNode.querySelector(qstr);
                switch (key) {
                    case 'title':
                    case 'qty': elementNode.textContent = order[key]; break;
                    case 'price': elementNode.textContent = order[key].toFixed(2); break;
                    case 'imgSrc': elementNode.src = "images/" + order[key]; break;
                }
            }
        }

        // 移除隐藏属性
        orderNode.classList.remove('d-none');
    }
}
//显示购物车所有总数据
function displayTotalData(cart) {
    let unitsNode = document.querySelector('[data-name="units"]');
    cartData = cart.getDataFromLocalStorage();
    unitsNode.textContent = cartData.units;
    let selectedAmountNode = document.querySelector('[data-name="selectedAmount"]');
    selectedAmountNode.textContent = cart.getSelectedAmount().toFixed(2);
    let selectedQtyNode = document.querySelector('[data-name="selectedQty"]');
    selectedQtyNode.textContent = cart.getSelectedQty();
}

// 注册事件函数
function regEvent() {

    // 为清空按钮设计单击事件
    let clearCartBtn = document.querySelector('[data-operator="clearAll"]');
    clearCartBtn.onclick = clearCartEventFun;

    // 为删除选中商品单击事件
    let deleteSelectedBtn = document.querySelector('[data-operator="deleteSelected"]');
    deleteSelectedBtn.onclick = deleteSelectedEventFun;


    // 为删除按钮设计单击事件
    let deleteItemBtns = document.querySelectorAll('[data-operator="deleteItem"]');
    for (const key in deleteItemBtns) {
        deleteItemBtns[key].onclick = deleteItemEventFun;
    }


    // 为加号按钮注册单击事件
    let increaseBtns = document.querySelectorAll('[data-operator="increase"]');
    for (const key in increaseBtns) {
        increaseBtns[key].onclick = changeQtyEventFun;
    }

    // 为减号按钮注册单击事件
    let decreaseBtns = document.querySelectorAll('[data-operator="decrease"]');
    for (const key in decreaseBtns) {
        decreaseBtns[key].onclick = changeQtyEventFun;
    }
    // 为订单项复选框注册单击事件
    let checkboxItems = document.querySelectorAll('[ data-operator="checkItem"]');
    for (const key in checkboxItems) {
        checkboxItems[key].onchange = checkItemEventFun;
    }
    // 为全选框注册单击事件
    let checkboxSelectAlls = document.querySelectorAll('[ data-operator="selectAll"]');
    for (const key in checkboxSelectAlls) {
        checkboxSelectAlls[key].onchange = checkAllEventFun;
    }

}

//删除当前商品的触发函数
function deleteItemEventFun(e) {
    let id = e.target.getAttribute("data-id");
    let cart = new ShoppingCart();
    // 删除购物车数据
    cart.deleteItem(id);
    // 移除结点
    let cartListNode = document.querySelector('#cartList');
    let currentItemNode = cartListNode.querySelector('[data-id="' + id + '"]');
    cartListNode.removeChild(currentItemNode);
    //设置总数
    displayTotalData(cart);
}

//清空购物车的触发函数
function clearCartEventFun() {
    let cart = new ShoppingCart();
    cart.clearCart();
    // 获取订单根节点
    let cartListNode = document.querySelector('#cartList');
    //保留样本节点
    let ExampleNode = (document.querySelector('#orderExample')).cloneNode(true);
    //清除订单根节点的所有元素
    cartListNode.innerHTML = "";
    //将样本节点挂接回列表根节点
    cartListNode.appendChild(ExampleNode);
    // 更新商品总数据
    displayTotalData(cart);
}
// 删除选中商品按钮触发函数
function deleteSelectedEventFun() {
    let checkboxItems = document.querySelectorAll('[ data-operator="checkItem"]');
    let idArray = new Array();
    for (let i = 1; i < checkboxItems.length; i++) {
        console.log(checkboxItems[i].checked);
        if (checkboxItems[i].checked) {
            idArray.push(checkboxItems[i].getAttribute("data-id"));
        }
    }
    console.log(idArray);
    let cart = new ShoppingCart();
    for (i in idArray) {
        id = idArray[i];
        cart.deleteItem(id);
        let cartListNode = document.querySelector('#cartList');
        let currentItemNode = cartListNode.querySelector('[data-id="' + id + '"]');
        cartListNode.removeChild(currentItemNode);
    }
    displayTotalData(cart);

}

// 增加减少按钮触发函数
function changeQtyEventFun(e) {
    console.log(e.target);
    // 获取事件节点id
    let id = e.target.getAttribute('data-id');
    //获取购物车订单列表根元素
    let cartListNode = document.querySelector('#cartList');
    // 获取当前订单行元素
    let currItemNode = cartListNode.querySelector('[data-id="' + id + '"]');
    // 获取当前订单数量节点元素
    let qtyNode = currItemNode.querySelector('[data-name="qty"]');
    // 获取当前订单原数量
    let qty = parseInt(qtyNode.textContent);
    // 获取当前操作符
    let op = e.target.textContent;
    // 根据操作符处理当前数量
    if (op == '+') {
        qty++;
    }
    else {
        qty--;
        if (qty <= 0) { qty = 1; return; }
    }
    // 将当前数量回填入页面
    qtyNode.textContent = qty;
    // 生成购物车实例   
    let cart = new ShoppingCart();
    // 根据新数量变更购物车数据
    cart.changeQty(id, op);
    // 获取购物车数据变更页面小计价格
    let index = cart.find(id);
    let subPriceNode = currItemNode.querySelector('[data-name="subPrice"]');
    let cartData = cart.getDataFromLocalStorage();
    subPriceNode.textContent = (cartData.orderList[index].qty * cartData.orderList[index].price).toFixed(2);
    // 变更页面其它总计价格
    displayTotalData(cart);
}
// 订单项复选框按钮触发函数
function checkItemEventFun(e) {
    let selectAllNodes = document.querySelectorAll('[data-operator="selectAll"]');
    let cart = new ShoppingCart();
    let id = e.target.getAttribute("data-id");
    let selectStatus = e.target.checked;
    cart.setItemSelectStatus(id, selectStatus);

    console.log(e.target.checked);
    if (selectStatus == false) {
        for (i in selectAllNodes) {
            selectAllNodes[i].checked = false;
        }
    }
    else {

        if (cart.getSelectedQty() == cart.getDataFromLocalStorage().totalQty) {
            for (i in selectAllNodes) {
                selectAllNodes[i].checked = true;
            }
        }
    }
    displayTotalData(cart);
}

function checkAllEventFun(e) {
    let currentNode = e.target;
    let checkboxSelectAlls = document.querySelectorAll('[ data-operator="selectAll"]');
    for (const i in checkboxSelectAlls) {
        checkboxSelectAlls[i].checked = currentNode.checked;
    }
    let cart = new ShoppingCart();
    cartData = cart.getDataFromLocalStorage();


    let checkboxItems = document.querySelectorAll('[ data-operator="checkItem"]');
    for (let i = 1; i < checkboxItems.length; i++) {
        let id = checkboxItems[i].getAttribute('data-id');
        checkboxItems[i].checked = currentNode.checked;
        cart.setItemSelectStatus(id, currentNode.checked);
    }

    displayTotalData(cart);
}

// 初始化
function init() {
    let cart = new ShoppingCart();
    let cartData = cart.getDataFromLocalStorage();
    displayOrderList(cartData);
    displayTotalData(cart);
    regEvent();
}

init();









