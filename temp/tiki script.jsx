/**
 * Tìm giá trị trong bảng chi tiết từ thuộc tính strSearch
 * @param {Chuỗi td cần tìm} strSearch
 */
function searchDetail(strSearch) {
  var tds = document.querySelectorAll(
    "#__next > div:nth-child(1) > main > div:nth-child(8) > div > div.left > div:nth-child(2) > div > table td"
  );

  for (var i = 0; i < tds.length; i += 2) {
    if (tds[i].innerText == strSearch) {
      return tds[i + 1].innerText;
    }
  }
  return "";
}
function convertDateMDY(m, d, y) {
  return m + "/" + d + "/" + y;
}
function copyToClipboard(str) {
  var el = document.createElement("textarea");
  el.value = str;
  document.body.appendChild(el);
  el.select();
  document.execCommand("copy");
  document.body.removeChild(el);
}
/**
 * Kiểm tra hình thu nhỏ có tồn tại hay ko
 * @param {img src} imageSrc
 */
function imageSmallExists(imageSrc) {
  var img = new Image();
  img.onerror = () => {
    alert("Hình thu nhỏ không tồn tại");
    console.error("Hình thu nhỏ ko tồn tại, chuyển sang sách khác.");
  };
  img.src =
    "https://salt.tikicdn.com/cache/w444/ts/product/" + imageSrc + ".jpg";
}

function setBookId(bookId) {
  localStorage.setItem("bookId", bookId);
}

function giamBookId() {
  var bookId = +localStorage.getItem("bookId");
  localStorage.setItem("bookId", --bookId);
}
////////////////////// end function /////////////////

function getAll() {
  var strEnd = getbook() + "\n" + getevaluate();
  copyToClipboard(strEnd);
}
function getbook() {
  var book_name = document.querySelector("h1.title").innerText;
  // chuoi chung: https://salt.tikicdn.com/cache/280x280/ts/product/
  // bỏ img large, img small đi, chỉ giữ lại 1 img thôi, thay đổi chuỗi chung để lấy hình
  var book_img = document
    .querySelector(
      "#__next > div:nth-child(1) > main > div:nth-child(4) > div > div.indexstyle__ProductImages-qd1z2k-2.cSuyir > div.group-images > div.thumbnail > div > div > img"
    )
    .src.slice(47, -4);
  imageSmallExists(book_img);
  var book_price = document
    .querySelector(
      "#__next > div:nth-child(1) > main > div:nth-child(4) > div > div.indexstyle__ProductContent-qd1z2k-3.hPysQm > div.body > div > div.left > div.price-and-icon > div.style__StyledProductPrice-sc-15mbtqi-0.hJdJUx > div > span.product-price__list-price"
    )
    .innerText.replaceAll(".", "")
    .replace("₫", "");
  var book_sale = document
    .querySelector(
      "#__next > div:nth-child(1) > main > div:nth-child(4) > div > div.indexstyle__ProductContent-qd1z2k-3.hPysQm > div.body > div > div.left > div.price-and-icon > div.style__StyledProductPrice-sc-15mbtqi-0.hJdJUx > div > span.product-price__current-price"
    )
    .innerText.replaceAll(".", "")
    .replace("₫", "");

  var shop_name = document.querySelector(
    "#__next > div:nth-child(1) > main > div:nth-child(4) > div > div.indexstyle__ProductContent-qd1z2k-3.hPysQm > div.body > div > div.right > div.style__StyledCurrentSeller-i5oomf-0.eDEtVI > div.seller-info > div.seller-icon-and-name > div > a > span:nth-child(1)"
  ).innerText;
  var arrDate = document
    .querySelector(
      "#__next > div:nth-child(1) > main > div:nth-child(8) > div > div.left > div:nth-child(2) > div > table > tbody > tr:nth-child(2) > td:nth-child(2)"
    )
    .innerText.split("-");

  var public_date = convertDateMDY(arrDate[0], 1, arrDate[1]);
  var page_number = searchDetail("Số trang");
  var cover_type = searchDetail("Loại bìa");
  var size = searchDetail("Kích thước");
  var width, height;
  width = height = 10;
  if (size !== "") {
    size = size.replace(" cm", "");
    var arr = size.split(" x ");
    width = arr[0];
    height = arr[1];
  }
  var translator = searchDetail("Dịch Giả");

  var article = document
    .querySelector(
      "#__next > div:nth-child(1) > main > div:nth-child(8) > div > div.left > div:nth-child(3) > div > div > div > div"
    )
    .innerHTML.replaceAll(' style="text-align: justify;"', "");

  var cat_name = document.querySelector(
    "#__next > div:nth-child(1) > main > div.Breadcrumb__Wrapper-sc-1a3qw0s-0.fNFkEn > div > div > a:nth-child(5)"
  ).innerText;
  var com_name = document.querySelector(
    "#__next > div:nth-child(1) > main > div:nth-child(8) > div > div.left > div:nth-child(2) > div > table > tbody > tr:nth-child(1) > td:nth-child(2)"
  ).innerText;

  var pub_name = document.querySelector(
    "#__next > div:nth-child(1) > main > div:nth-child(8) > div > div.left > div:nth-child(2) > div > table > tbody > tr:last-child > td:nth-child(2)"
  ).innerText;

  var aut_obj = document.querySelector(
    "#__next > div:nth-child(1) > main > div:nth-child(4) > div > div.indexstyle__ProductContent-qd1z2k-3.hPysQm > div.header > div.brand > span > h6 > a"
  );
  var aut_name = "";
  if (aut_obj == null) {
    console.warn("Chưa xác định được tác giả");
  } else {
    aut_name = aut_obj.innerText;
  }

  var strEnd = `exec spInsertBook @book_name = N'${book_name}', @cat_name = N'${cat_name}', @aut_name = N'${aut_name}', @page_number = ${page_number}, @book_img = '${book_img}', @book_price = ${book_price}, @book_sale = ${book_sale}, @public_date = '${public_date}', @width = ${width}, @height = ${height}, @cover_type = N'${cover_type}', @article = N'${article}', @translator = N'${translator}', @com_name = N'${com_name}', @pub_name = N'${pub_name}', @shop_name = N'${shop_name}';`;

  return strEnd;
}

function getevaluate() {
  var arrUsername = [
    "ndtai",
    "ntphong",
    "nhdhao",
    "hqdung",
    "ltkiet",
    "hdhuy",
    "ttlong",
    "hnthien",
    "dkhy",
    "ntkanh",
    "ctnhung",
    "ntloc",
    "ndquang",
    "pmthe",
    "hqbao",
    "sssbath",
    "ddkhanh",
    "vdhieu",
    "lmquy",
    "nhhiep",
    "ddnhue",
    "lnminh",
    "nttthuy",
    "dqlai",
    "ptloc",
    "nvan",
    "ptttam",
    "httri",
    "ltduy",
    "httam",
    "hltmanh",
    "dhkhai",
    "pmthanh",
    "bndtrung",
    "lvdai",
    "nvchung",
    "ntkduy",
    "lqcuong",
    "dqviet",
    "ltlong",
    "lvqan",
    "nthoang",
    "dnmquoc",
    "ltlong",
    "ltsong",
    "ptkien",
    "nvthai",
    "nhdhao",
    "dhkhai",
    "mhvan",
    "hltmanh",
    "ttson",
    "vtluan",
    "tu123",
    "nhtuan",
    "tylnhi",
    "toshiko",
    "thanhvy",
    "ndtai",
  ];
  for (let i = arrUsername.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [arrUsername[i], arrUsername[j]] = [arrUsername[j], arrUsername[i]];
  }

  var lstEvaluate = document.querySelectorAll(
    "#__next > div:nth-child(1) > main > div:nth-child(9) > div > div.customer-reviews__inner > div"
  );
  var results = "";

  var bookId = +localStorage.getItem("bookId");
  for (var i = 4; i < lstEvaluate.length - 1; i++) {
    var arrDate = lstEvaluate[i]
      .querySelector(".review-comment__avatar-date")
      .innerText.replace("Nhận xét vào ", "")
      .replace(" tháng ", "/")
      .replace(", ", "/")
      .split("/");

    var date = convertDateMDY(arrDate[1], arrDate[0], arrDate[2]);
    var rate =
      lstEvaluate[i]
        .querySelector(".Stars__StyledStars-sc-15olgyg-0.jucQbJ div")
        .style.width.slice(0, -1) / 20;

    var eva_title = lstEvaluate[i].querySelector(".review-comment__title")
      .innerText;
    var eva_content = lstEvaluate[i].querySelector(".review-comment__content")
      .innerText;

    var arrImgs = lstEvaluate[i].querySelectorAll(
      ".review-comment__images div"
    );
    var eva_imgs = "";
    if (arrImgs !== null) {
      arrImgs.forEach((i) => {
        eva_imgs += i.style.backgroundImage.slice(40, -6) + ";";
      });
    }
    console.warn("line 210 - bookId: ", bookId);
    results += `('${arrUsername[i]
      }', ${bookId}, '${date}', N'${eva_title}', N'${eva_content}', ${rate}, '${eva_imgs.slice(
        0,
        -1
      )}'),`;
  }
  var strEnd = "insert into evaluate values " + results.slice(0, -1) + ";";
  setBookId(+bookId + 1);
  console.warn("book id new: " + localStorage.getItem("bookId"));

  copyToClipboard(strEnd);

  return strEnd;
}
/*
ttps://salt.tikicdn.com/cache/280x280/ts/product/c5/ae/c1/4c7861d860c406517a745d91b56db9b5.jpg
https://salt.tikicdn.com/cache/w444/ts/product/c5/ae/c1/4c7861d860c406517a745d91b56db9b5.jpg

https://salt.tikicdn.com/cache/280x280/ts/product/36/56/ce/a55e1af163509a0b239c011adc2c362f.jpg
https://salt.tikicdn.com/cache/w444/ts/product/36/56/ce/a55e1af163509a0b239c011adc2c362f.jpg

https://salt.tikicdn.com/cache/280x280/ts/product/b4/eb/ed/e3f867f1cf443888ee69ccba1bdb6542.jpg
https://salt.tikicdn.com/cache/w444/ts/product/b4/eb/ed/e3f867f1cf443888ee69ccba1bdb6542.jpg
*/

/** img evaluate
 * https://vcdn.tikicdn.com/ts/review/00/bf/90/187631df0ca80deeb8c410d4b9e4d1ba.jpg
 * https://vcdn.tikicdn.com/ts/review/69/75/99/916ddf9ce4114f0151e6a0b83eb769a9.jpg
 * https://vcdn.tikicdn.com/ts/review/92/f8/35/a8cec38a78546967e2f0b90dfb07cd66.jpg
 *
 * https://vcdn.tikicdn.com/ts/review/
 * phần chung length = 35;
 */

/*

exec spInsertBook
@book_name = N'${book_name}',
@book_img = '${book_img}',
@book_price = ${book_price},
@book_sale = ${book_sale},
@public_date = '${public_date}',
@width = ${width},
@height = ${height},
@page_number = ${page_number},
@cover_type = N'${cover_type}',
@article = N'${article}',
@translator = N'${translator}',
@aut_name = N'${aut_name}',
@com_name = N'${com_name}',
@pub_name = N'${pub_name}',
@cat_name = N'${cat_name}';

exec spInsertBook @book_name = N'${book_name}', @book_img = '${book_img}', @book_price = ${book_price}, @book_sale = ${book_sale}, @public_date = '${public_date}', @width = ${width}, @height = ${height}, @page_number = ${page_number}, @cover_type = N'${cover_type}', @article = N'${article}', @translator = N'${translator}', @aut_name = N'${aut_name}', @com_name = N'${com_name}', @pub_name = N'${pub_name}', @cat_name = N'${cat_name}';
 */
