# Copyright David Stone 2015.
# Distributed under the Boost Software License, Version 1.0.
# (See accompanying file LICENSE_1_0.txt or copy at
# http://www.boost.org/LICENSE_1_0.txt)

class debug:
	__generate_debug_symbols = '-g3'
	__sanitizers = [
		'-fsanitize=undefined',
		'-fsanitize=address',
	]
	compile_flags = __sanitizers + [
		__generate_debug_symbols,
	]
	compile_flags_release = [
		__generate_debug_symbols,
	]

	link_flags =  __sanitizers
	link_flags_release = [
	]

