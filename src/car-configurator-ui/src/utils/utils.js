export function formatNumber(value) {
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};

export function formatPrice(value, zero = "included") {
  if (isNaN(value)) return null;
  return value === 0 ? zero : `€ ${formatNumber(value)}`;
};


export function joinUrlWithRoute(url, route) {
  return trimEnd("/", url) + "/" + trimStart("/", route);
}

export function trimStart(character, string) {
  var startIndex = 0;

  while (string[startIndex] === character) {
    startIndex++;
  }

  return string.substr(startIndex);
}

export function trimEnd(character, string) {
  // Because why the hell not
  return reverse(trimStart(character, reverse(string)));
}

function reverse(value) {
  return value
    .split("")
    .reverse()
    .join("");
}

export function getCookie(name) {
  var dc = document.cookie;
  var prefix = name + "=";
  var begin = dc.indexOf("; " + prefix);
  if (begin === -1) {
    begin = dc.indexOf(prefix);
    if (begin !== 0) return null;
  } else {
    begin += 2;
    var end = document.cookie.indexOf(";", begin);
    if (end === -1) {
      end = dc.length;
    }
  }

  return decodeURI(dc.substring(begin + prefix.length, end));
}